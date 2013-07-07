﻿using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Threading;
using System.IO;

namespace QBfinance_auto
{
    public delegate void AutoQueryProgressChangedDelegate(object sender, AutoQueryProgressChangedEventArgs e);

    public class AutoQueryProgressChangedEventArgs
    {
        public int CurrentQuery { get; private set; }
        public int Queries { get; private set; }
        public bool Done { get; private set; }

        public AutoQueryProgressChangedEventArgs(int currentQuery, int queries, bool done)
        {
            CurrentQuery = currentQuery;
            Queries = queries;
            Done = done;
        }
    }

    /* Механизм работы:
             * интервал обозначает время между двумя запросами с одного IP-адреса.
             * Один запрос идёт подряд с максимальной скоростью с разных IP-адресов.
             * Когда интервал истекает, то адрес прокси меняется на самый первый в списке,
             * и программа переключается на следующий запрос. */
    public class AutoQuery
    {
        string[] _proxies;
        string[] _queries;
        int _currentQuery;

        string _baseUrl;
        int _queryInterval;
        int _proxyTimeout;

        ILogger _logger;

        Random _random = new Random(DateTime.Now.Millisecond);

        //progress
        //int _ipCount = 0;
        int _queryCount = 0;

        public AutoQuery(string baseUrl, string[] proxies, string[] queries, int queryInterval, int proxyTimeout, ILogger logger)
        {
            _baseUrl = baseUrl;
            _proxies = proxies;
            _queries = queries;
            _queryInterval = queryInterval;
            _proxyTimeout = proxyTimeout;
            _logger = logger;
        }

        public void Start()
        {
            _currentQuery = 0;

            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromMilliseconds(_proxyTimeout));
            
            for (int i = 0; i < _queries.Length; i++)
            {
                ExecuteQuery(driver);
                if (_currentQuery < _queries.Length-1)
                    _currentQuery++;
            }

            OnProgressChanged(true);
            Stop();
        }

        public void Stop()
        {
            ProxyService.DisableProxy();
        }

        private void ExecuteQuery(IWebDriver driver)
        {
            DateTime beginTime = DateTime.Now;
            string currentProxy = "";

            for (int i = 0; i < _proxies.Length; i++)
            {
                string query = _queries[_currentQuery];
                try
                {
                    ProxyService.SetProxy(_proxies[i]);
                    currentProxy = _proxies[i];

                    driver.Navigate().GoToUrl(_baseUrl);
                    IWebElement text = driver.FindElement(By.Id("text"));
                    text.Click();
                    text.Clear();
                    text.SendKeys(query);
                    IWebElement button = driver.FindElement(By.CssSelector("input.b-form-button__input"));
                    button.Click();
                    
                    if (!CheckTitle(driver.Title, query))
                        throw new WebException("Probably captcha");
                    if (!CheckUrl(driver.Url))
                        throw new WebException("Probably captcha");

                    driver.Manage().Cookies.DeleteAllCookies();

                    _queryCount++;
                    OnProgressChanged(false);
                }
                catch (Exception ex)
                {
                    _logger.WriteLine(String.Format("{0} - {1}: {2} ({3})", DateTime.Now.ToString(), currentProxy, ex.GetType().Name, ex.Message));
                }

                //Thread.Sleep(_random.Next(_proxyInterval) + _proxyInterval / 2);
            }

            double delta = (DateTime.Now - beginTime).TotalMilliseconds;
            if (delta < _queryInterval)
                Thread.Sleep(_queryInterval - (int)Math.Round(delta));
        }

        static bool CheckTitle(string title, string query)
        {
            return title != "Ой!";//title.Contains(query);
        }

        static bool CheckUrl(string url)
        {
            return url.Contains("yandsearch");
        }

        //public event EventHandler<AutoQueryProgressChangedEventArgs> ProgressChanged;
        public event AutoQueryProgressChangedDelegate ProgressChanged;

        protected void OnProgressChanged(bool done)
        {
            if (done)
                _logger.Close();

            if (ProgressChanged != null)
                ProgressChanged(this, new AutoQueryProgressChangedEventArgs(_currentQuery+1, _queryCount, done));
        }
    }
}