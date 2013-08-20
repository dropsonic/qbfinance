namespace QBfinance_auto
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lProxiesFileName = new System.Windows.Forms.Label();
            this.bLoadProxies = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bLoadQueries = new System.Windows.Forms.Button();
            this.lQueriesFileName = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lQueryInterval = new System.Windows.Forms.Label();
            this.udQueryInterval = new System.Windows.Forms.NumericUpDown();
            this.bStart = new System.Windows.Forms.Button();
            this.lModule = new System.Windows.Forms.Label();
            this.lQueriesCountLabel = new System.Windows.Forms.Label();
            this.lQueriesCount = new System.Windows.Forms.Label();
            this.lCurrentQuery = new System.Windows.Forms.Label();
            this.lCurrentQueryLabel = new System.Windows.Forms.Label();
            this.udProxyTimeout = new System.Windows.Forms.NumericUpDown();
            this.lProxyInterval = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.udMaxTime = new System.Windows.Forms.NumericUpDown();
            this.lMaxTime = new System.Windows.Forms.Label();
            this.cbModule = new System.Windows.Forms.ComboBox();
            this.lLogLabel = new System.Windows.Forms.Label();
            this.lLog = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.udQueryInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udProxyTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxTime)).BeginInit();
            this.SuspendLayout();
            // 
            // lProxiesFileName
            // 
            this.lProxiesFileName.AutoSize = true;
            this.lProxiesFileName.Location = new System.Drawing.Point(175, 17);
            this.lProxiesFileName.Name = "lProxiesFileName";
            this.lProxiesFileName.Size = new System.Drawing.Size(165, 13);
            this.lProxiesFileName.TabIndex = 3;
            this.lProxiesFileName.Text = "Имя файла со списком прокси";
            this.lProxiesFileName.Visible = false;
            // 
            // bLoadProxies
            // 
            this.bLoadProxies.Location = new System.Drawing.Point(12, 12);
            this.bLoadProxies.Name = "bLoadProxies";
            this.bLoadProxies.Size = new System.Drawing.Size(157, 23);
            this.bLoadProxies.TabIndex = 4;
            this.bLoadProxies.Text = "Загрузить список прокси";
            this.bLoadProxies.UseVisualStyleBackColor = true;
            this.bLoadProxies.Click += new System.EventHandler(this.bLoadFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            // 
            // bLoadQueries
            // 
            this.bLoadQueries.Location = new System.Drawing.Point(12, 54);
            this.bLoadQueries.Name = "bLoadQueries";
            this.bLoadQueries.Size = new System.Drawing.Size(157, 23);
            this.bLoadQueries.TabIndex = 5;
            this.bLoadQueries.Text = "Загрузить список запросов";
            this.bLoadQueries.UseVisualStyleBackColor = true;
            this.bLoadQueries.Click += new System.EventHandler(this.bLoadQueries_Click);
            // 
            // lQueriesFileName
            // 
            this.lQueriesFileName.AutoSize = true;
            this.lQueriesFileName.Location = new System.Drawing.Point(175, 59);
            this.lQueriesFileName.Name = "lQueriesFileName";
            this.lQueriesFileName.Size = new System.Drawing.Size(177, 13);
            this.lQueriesFileName.TabIndex = 6;
            this.lQueriesFileName.Text = "Имя файла со списком запросов";
            this.lQueriesFileName.Visible = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lQueryInterval
            // 
            this.lQueryInterval.AutoSize = true;
            this.lQueryInterval.Location = new System.Drawing.Point(9, 90);
            this.lQueryInterval.Name = "lQueryInterval";
            this.lQueryInterval.Size = new System.Drawing.Size(142, 13);
            this.lQueryInterval.TabIndex = 8;
            this.lQueryInterval.Text = "Интервал запросов (в мс):";
            this.toolTip.SetToolTip(this.lQueryInterval, "Минимальный интервал между двумя запросами\r\n(в миллисекундах, 1с = 1000 мс).");
            // 
            // udQueryInterval
            // 
            this.udQueryInterval.Location = new System.Drawing.Point(178, 88);
            this.udQueryInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.udQueryInterval.Name = "udQueryInterval";
            this.udQueryInterval.Size = new System.Drawing.Size(120, 20);
            this.udQueryInterval.TabIndex = 9;
            this.toolTip.SetToolTip(this.udQueryInterval, "Минимальный интервал между двумя запросами\r\n(в миллисекундах, 1с = 1000 мс).");
            this.udQueryInterval.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 243);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(157, 23);
            this.bStart.TabIndex = 10;
            this.bStart.Text = "Начать загрузку";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // lModule
            // 
            this.lModule.AutoSize = true;
            this.lModule.Location = new System.Drawing.Point(9, 207);
            this.lModule.Name = "lModule";
            this.lModule.Size = new System.Drawing.Size(127, 13);
            this.lModule.TabIndex = 11;
            this.lModule.Text = "Используемый модуль:";
            // 
            // lQueriesCountLabel
            // 
            this.lQueriesCountLabel.AutoSize = true;
            this.lQueriesCountLabel.Location = new System.Drawing.Point(175, 243);
            this.lQueriesCountLabel.Name = "lQueriesCountLabel";
            this.lQueriesCountLabel.Size = new System.Drawing.Size(150, 13);
            this.lQueriesCountLabel.TabIndex = 13;
            this.lQueriesCountLabel.Text = "Всего выполнено запросов:";
            this.lQueriesCountLabel.Visible = false;
            // 
            // lQueriesCount
            // 
            this.lQueriesCount.AutoSize = true;
            this.lQueriesCount.Location = new System.Drawing.Point(343, 243);
            this.lQueriesCount.Name = "lQueriesCount";
            this.lQueriesCount.Size = new System.Drawing.Size(0, 13);
            this.lQueriesCount.TabIndex = 14;
            this.lQueriesCount.Visible = false;
            // 
            // lCurrentQuery
            // 
            this.lCurrentQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock;
            this.lCurrentQuery.AutoSize = true;
            this.lCurrentQuery.Location = new System.Drawing.Point(343, 271);
            this.lCurrentQuery.Name = "lCurrentQuery";
            this.lCurrentQuery.Size = new System.Drawing.Size(0, 13);
            this.lCurrentQuery.TabIndex = 16;
            this.lCurrentQuery.Visible = false;
            // 
            // lCurrentQueryLabel
            // 
            this.lCurrentQueryLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock;
            this.lCurrentQueryLabel.AutoSize = true;
            this.lCurrentQueryLabel.Location = new System.Drawing.Point(175, 271);
            this.lCurrentQueryLabel.Name = "lCurrentQueryLabel";
            this.lCurrentQueryLabel.Size = new System.Drawing.Size(144, 13);
            this.lCurrentQueryLabel.TabIndex = 15;
            this.lCurrentQueryLabel.Text = "Выполнено строк запроса:";
            this.lCurrentQueryLabel.Visible = false;
            // 
            // udProxyTimeout
            // 
            this.udProxyTimeout.Location = new System.Drawing.Point(178, 122);
            this.udProxyTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.udProxyTimeout.Name = "udProxyTimeout";
            this.udProxyTimeout.Size = new System.Drawing.Size(120, 20);
            this.udProxyTimeout.TabIndex = 18;
            this.toolTip.SetToolTip(this.udProxyTimeout, "Время, в течение которого программа\r\nпытается соединиться с прокси-сервером\r\nи за" +
        "грузить страницу\r\n(в миллисекундах, 1с = 1000 мс).");
            this.udProxyTimeout.Value = new decimal(new int[] {
            45000,
            0,
            0,
            0});
            // 
            // lProxyInterval
            // 
            this.lProxyInterval.AutoSize = true;
            this.lProxyInterval.Location = new System.Drawing.Point(9, 124);
            this.lProxyInterval.Name = "lProxyInterval";
            this.lProxyInterval.Size = new System.Drawing.Size(99, 26);
            this.lProxyInterval.TabIndex = 17;
            this.lProxyInterval.Text = "Таймаут загрузки\r\nстраницы (в мс):";
            this.toolTip.SetToolTip(this.lProxyInterval, "Время, в течение которого программа\r\nпытается соединиться с прокси-сервером\r\nи за" +
        "грузить страницу\r\n(в миллисекундах, 1с = 1000 мс).");
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // udMaxTime
            // 
            this.udMaxTime.Location = new System.Drawing.Point(178, 159);
            this.udMaxTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.udMaxTime.Name = "udMaxTime";
            this.udMaxTime.Size = new System.Drawing.Size(120, 20);
            this.udMaxTime.TabIndex = 20;
            this.toolTip.SetToolTip(this.udMaxTime, "Максимальное время, отведённое на выполнение запроса.\r\nПосле этого времени програ" +
        "мма перейдёт к следующему\r\nпрокси-серверу.\r\n(в миллисекундах, 1с = 1000 мс).");
            this.udMaxTime.Value = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            // 
            // lMaxTime
            // 
            this.lMaxTime.AutoSize = true;
            this.lMaxTime.Location = new System.Drawing.Point(9, 161);
            this.lMaxTime.Name = "lMaxTime";
            this.lMaxTime.Size = new System.Drawing.Size(119, 26);
            this.lMaxTime.TabIndex = 19;
            this.lMaxTime.Text = "Максимальное время\r\nзапроса (в мс):";
            this.toolTip.SetToolTip(this.lMaxTime, "Максимальное время, отведённое на выполнение запроса.\r\nПосле этого времени програ" +
        "мма перейдёт к следующему\r\nпрокси-серверу.\r\n(в миллисекундах, 1с = 1000 мс).\r\n");
            // 
            // cbModule
            // 
            this.cbModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModule.FormattingEnabled = true;
            this.cbModule.Location = new System.Drawing.Point(178, 204);
            this.cbModule.Name = "cbModule";
            this.cbModule.Size = new System.Drawing.Size(222, 21);
            this.cbModule.TabIndex = 21;
            // 
            // lLogLabel
            // 
            this.lLogLabel.AutoSize = true;
            this.lLogLabel.Location = new System.Drawing.Point(9, 300);
            this.lLogLabel.Name = "lLogLabel";
            this.lLogLabel.Size = new System.Drawing.Size(116, 13);
            this.lLogLabel.TabIndex = 22;
            this.lLogLabel.Text = "Имя файла с логами:";
            this.lLogLabel.Visible = false;
            // 
            // lLog
            // 
            this.lLog.AutoSize = true;
            this.lLog.Location = new System.Drawing.Point(175, 300);
            this.lLog.MaximumSize = new System.Drawing.Size(400, 0);
            this.lLog.Name = "lLog";
            this.lLog.Size = new System.Drawing.Size(113, 13);
            this.lLog.TabIndex = 24;
            this.lLog.TabStop = true;
            this.lLog.Text = "Имя файла с логами";
            this.lLog.Visible = false;
            this.lLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lLog_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 359);
            this.Controls.Add(this.lLog);
            this.Controls.Add(this.lLogLabel);
            this.Controls.Add(this.cbModule);
            this.Controls.Add(this.udMaxTime);
            this.Controls.Add(this.lMaxTime);
            this.Controls.Add(this.udProxyTimeout);
            this.Controls.Add(this.lProxyInterval);
            this.Controls.Add(this.lCurrentQuery);
            this.Controls.Add(this.lCurrentQueryLabel);
            this.Controls.Add(this.lQueriesCount);
            this.Controls.Add(this.lQueriesCountLabel);
            this.Controls.Add(this.lModule);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.udQueryInterval);
            this.Controls.Add(this.lQueryInterval);
            this.Controls.Add(this.lQueriesFileName);
            this.Controls.Add(this.bLoadQueries);
            this.Controls.Add(this.bLoadProxies);
            this.Controls.Add(this.lProxiesFileName);
            this.Name = "MainForm";
            this.Text = "QBfinance";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.udQueryInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udProxyTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lProxiesFileName;
        private System.Windows.Forms.Button bLoadProxies;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button bLoadQueries;
        private System.Windows.Forms.Label lQueriesFileName;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lQueryInterval;
        private System.Windows.Forms.NumericUpDown udQueryInterval;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label lModule;
        private System.Windows.Forms.Label lQueriesCountLabel;
        private System.Windows.Forms.Label lQueriesCount;
        private System.Windows.Forms.Label lCurrentQuery;
        private System.Windows.Forms.Label lCurrentQueryLabel;
        private System.Windows.Forms.NumericUpDown udProxyTimeout;
        private System.Windows.Forms.Label lProxyInterval;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.NumericUpDown udMaxTime;
        private System.Windows.Forms.Label lMaxTime;
        private System.Windows.Forms.ComboBox cbModule;
        private System.Windows.Forms.Label lLogLabel;
        private System.Windows.Forms.LinkLabel lLog;
    }
}

