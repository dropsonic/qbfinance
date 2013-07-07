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
            this.lQueryUrl = new System.Windows.Forms.Label();
            this.tbQueryUrl = new System.Windows.Forms.TextBox();
            this.lQueriesCountLabel = new System.Windows.Forms.Label();
            this.lQueriesCount = new System.Windows.Forms.Label();
            this.lCurrentQuery = new System.Windows.Forms.Label();
            this.lCurrentQueryLabel = new System.Windows.Forms.Label();
            this.udProxyTimeout = new System.Windows.Forms.NumericUpDown();
            this.lProxyInterval = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udQueryInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udProxyTimeout)).BeginInit();
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
            this.udQueryInterval.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 202);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(157, 23);
            this.bStart.TabIndex = 10;
            this.bStart.Text = "Начать загрузку";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // lQueryUrl
            // 
            this.lQueryUrl.AutoSize = true;
            this.lQueryUrl.Location = new System.Drawing.Point(9, 166);
            this.lQueryUrl.Name = "lQueryUrl";
            this.lQueryUrl.Size = new System.Drawing.Size(113, 13);
            this.lQueryUrl.TabIndex = 11;
            this.lQueryUrl.Text = "Адрес для запросов:";
            // 
            // tbQueryUrl
            // 
            this.tbQueryUrl.Location = new System.Drawing.Point(178, 163);
            this.tbQueryUrl.Name = "tbQueryUrl";
            this.tbQueryUrl.Size = new System.Drawing.Size(391, 20);
            this.tbQueryUrl.TabIndex = 12;
            this.tbQueryUrl.Text = "http://yandex.ru";
            // 
            // lQueriesCountLabel
            // 
            this.lQueriesCountLabel.AutoSize = true;
            this.lQueriesCountLabel.Location = new System.Drawing.Point(175, 202);
            this.lQueriesCountLabel.Name = "lQueriesCountLabel";
            this.lQueriesCountLabel.Size = new System.Drawing.Size(150, 13);
            this.lQueriesCountLabel.TabIndex = 13;
            this.lQueriesCountLabel.Text = "Всего выполнено запросов:";
            this.lQueriesCountLabel.Visible = false;
            // 
            // lQueriesCount
            // 
            this.lQueriesCount.AutoSize = true;
            this.lQueriesCount.Location = new System.Drawing.Point(343, 202);
            this.lQueriesCount.Name = "lQueriesCount";
            this.lQueriesCount.Size = new System.Drawing.Size(0, 13);
            this.lQueriesCount.TabIndex = 14;
            this.lQueriesCount.Visible = false;
            // 
            // lCurrentQuery
            // 
            this.lCurrentQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock;
            this.lCurrentQuery.AutoSize = true;
            this.lCurrentQuery.Location = new System.Drawing.Point(343, 230);
            this.lCurrentQuery.Name = "lCurrentQuery";
            this.lCurrentQuery.Size = new System.Drawing.Size(0, 13);
            this.lCurrentQuery.TabIndex = 16;
            this.lCurrentQuery.Visible = false;
            // 
            // lCurrentQueryLabel
            // 
            this.lCurrentQueryLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock;
            this.lCurrentQueryLabel.AutoSize = true;
            this.lCurrentQueryLabel.Location = new System.Drawing.Point(175, 230);
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
            this.udProxyTimeout.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // lProxyInterval
            // 
            this.lProxyInterval.AutoSize = true;
            this.lProxyInterval.Location = new System.Drawing.Point(9, 124);
            this.lProxyInterval.Name = "lProxyInterval";
            this.lProxyInterval.Size = new System.Drawing.Size(124, 13);
            this.lProxyInterval.TabIndex = 17;
            this.lProxyInterval.Text = "Таймаут прокси (в мс):";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 263);
            this.Controls.Add(this.udProxyTimeout);
            this.Controls.Add(this.lProxyInterval);
            this.Controls.Add(this.lCurrentQuery);
            this.Controls.Add(this.lCurrentQueryLabel);
            this.Controls.Add(this.lQueriesCount);
            this.Controls.Add(this.lQueriesCountLabel);
            this.Controls.Add(this.tbQueryUrl);
            this.Controls.Add(this.lQueryUrl);
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
        private System.Windows.Forms.Label lQueryUrl;
        private System.Windows.Forms.TextBox tbQueryUrl;
        private System.Windows.Forms.Label lQueriesCountLabel;
        private System.Windows.Forms.Label lQueriesCount;
        private System.Windows.Forms.Label lCurrentQuery;
        private System.Windows.Forms.Label lCurrentQueryLabel;
        private System.Windows.Forms.NumericUpDown udProxyTimeout;
        private System.Windows.Forms.Label lProxyInterval;
    }
}

