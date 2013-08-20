using QBfinance_auto.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace QBfinance_auto
{
    public partial class MainForm : Form
    {
        AutoQuery _autoQuery;
        string[] _proxies;
        string[] _queries;

        bool _started = false;

        public MainForm()
        {
            InitializeComponent();
            try
            {
                var modules = LoadModules(Application.StartupPath).ToArray();
                cbModule.Items.AddRange(modules);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки модулей:\n" + ex.Message, String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bLoadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _proxies = File.ReadAllLines(openFileDialog.FileName);
                lProxiesFileName.Text = openFileDialog.FileName;
                lProxiesFileName.Visible = true;
            }
        }

        private void bLoadQueries_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _queries = File.ReadAllLines(openFileDialog.FileName, Encoding.GetEncoding(1251));
                lQueriesFileName.Text = openFileDialog.FileName;
                lQueriesFileName.Visible = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _queries.Shuffle(); //перемешиваем запросы, чтобы сделать случайный их порядок
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (_started)
            {
                if (_autoQuery != null)
                    _autoQuery.Cancel();
                _started = false;
                ChangeVisualState();
            }
            else
            {
                if (_proxies == null || _queries == null)
                {
                    MessageBox.Show("Для начала работы необходимо загрузить списки прокси и запросов.");
                    return;
                }

                if (cbModule.SelectedItem == null)
                {
                    MessageBox.Show("Для начала работы необходимо выбрать используемый модуль");
                    return;
                }

                string logFileName = "log (" + DateTime.Now.ToString("dd.MM.yyyy HH-mm-ss", System.Globalization.CultureInfo.InvariantCulture) + ").txt";
                lLog.Text = Directory.GetCurrentDirectory() + "\\" + logFileName;
                var options = new AutoQuery.Options((int)udQueryInterval.Value, (int)udProxyTimeout.Value, (int)udMaxTime.Value, cbJSEnabled.Checked);
                _autoQuery = new AutoQuery((ModuleBase)cbModule.SelectedItem, _proxies, _queries,
                                           options,
                                           new Logger(logFileName));
                _autoQuery.ProgressChanged += _autoQuery_ProgressChanged;

                _started = true;
                ChangeVisualState();

                ThreadPool.QueueUserWorkItem(o => _autoQuery.Start());
            }
        }

        void ChangeVisualState()
        {
            bStart.Text = _started ? "Остановить" : "Начать загрузку";
            lQueriesCount.Visible = _started;
            lQueriesCountLabel.Visible = _started;
            lCurrentQuery.Visible = _started;
            lCurrentQueryLabel.Visible = _started;
            bLoadProxies.Enabled = !_started;
            bLoadQueries.Enabled = !_started;
            udQueryInterval.Enabled = !_started;
            udProxyTimeout.Enabled = !_started;
            udMaxTime.Enabled = !_started;
            cbJSEnabled.Enabled = !_started;
            cbModule.Enabled = !_started;
            lLogLabel.Visible = _started;
            lLog.Visible = _started;
        }

        void _autoQuery_ProgressChanged(object sender, AutoQueryProgressChangedEventArgs e)
        {
            Invoke(new AutoQueryProgressChangedDelegate(ShowProgress), sender, e);
        }

        void ShowProgress(object sender, AutoQueryProgressChangedEventArgs e)
        {
            if (e.Done)
            {
                MessageBox.Show("Задача выполнена!");
                ChangeVisualState();
            }

            lQueriesCount.Text = e.Queries.ToString();
            lCurrentQuery.Text = String.Format("{0} из {1}", e.CurrentQuery, _queries.Length);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProxyService.DisableProxy();
        }

        private IEnumerable<ModuleBase> LoadModules(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException();

            var files = Directory.EnumerateFiles(path, "*.dll", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var types = Assembly.LoadFrom(file).GetExportedTypes();
                foreach (var type in types)
                {
                    if (type.IsClass && type.BaseType == typeof(ModuleBase))
                        yield return (ModuleBase)Activator.CreateInstance(type);
                }
            }
        }

        private void lLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lLog.Text);
        }
    }
}
