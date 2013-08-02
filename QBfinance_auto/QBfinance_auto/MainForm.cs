using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        public MainForm()
        {
            InitializeComponent();
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
            if (_proxies == null || _queries == null)
            {
                MessageBox.Show("Для начала работы необходимо загрузить списки прокси и запросов.");
                return;
            }

            _autoQuery = new YandexAutoQuery(tbQueryUrl.Text, _proxies, _queries,
                                       (int)udQueryInterval.Value, (int)udProxyTimeout.Value, (int)udMaxTime.Value,
                                       new Logger("log.txt"));
            _autoQuery.ProgressChanged += _autoQuery_ProgressChanged;
            lQueriesCount.Visible = true;
            lQueriesCountLabel.Visible = true;
            lCurrentQuery.Visible = true;
            lCurrentQueryLabel.Visible = true;
            ThreadPool.QueueUserWorkItem(o => _autoQuery.Start());
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
            }

            lQueriesCount.Text = e.Queries.ToString();
            lCurrentQuery.Text = String.Format("{0} из {1}", e.CurrentQuery, _queries.Length);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProxyService.DisableProxy();
        }
    }
}
