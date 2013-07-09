using OpenQA.Selenium;
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
    public abstract class AutoQuery
    {
        string[] _proxies;
        string[] _queries;
        int _currentQuery;

        protected string BaseUrl { get; set; }
        int _queryInterval;
        int _proxyTimeout;
        int _maxTime;

        ILogger _logger;

        Random _random = new Random(DateTime.Now.Millisecond);

        //progress
        //int _ipCount = 0;
        int _queryCount = 0;

        public AutoQuery(string baseUrl, string[] proxies, string[] queries,
            int queryInterval, int proxyTimeout, int maxTime, ILogger logger)
        {
            BaseUrl = baseUrl;
            _proxies = proxies;
            _queries = queries;
            _queryInterval = queryInterval;
            _proxyTimeout = proxyTimeout;
            _maxTime = maxTime;
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

                    //using (Timer timer = new Timer(
                    //    (state) => 
                    //    {
                    //        ((ManualResetEventSlim)state).Set();
                    //    }, mre, _maxTime, Timeout.Infinite))
                    //{
                    //    DoQuery(driver, query);
                    //    mre.Set();
                    //}

                    //Запускаем сам запрос в браузере в новом потоке
                    ManualResetEventSlim mre = new ManualResetEventSlim(false);
                    Thread thread = new Thread(p =>
                    {
                        try
                        {
                            DoQuery(driver, query);
                            mre.Set();
                        }
                        catch (Exception tEx)
                        {
                            _logger.WriteLine(String.Format("{0} - {1}: {2} ({3})", DateTime.Now.ToString(), currentProxy, tEx.GetType().Name, tEx.Message));
                        }
                    });
                    thread.Start(mre);
                    //Ждём и проверяем, успел ли выполниться запрос
                    if (mre.Wait(_maxTime) == false)
                        throw new WebException("Время запроса истекло.", WebExceptionStatus.Timeout);

                    if (!CheckTitle(driver.Title, query))
                        throw new WebException("Возможно, captcha (причина: title).");
                    if (!CheckUrl(driver.Url))
                        throw new WebException("Возможно, captcha (причина: URL).");

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

        /// <summary>
        /// Метод, определяющий логику действий на странице (ввод поискового запроса, нажатие кнопок и т.д.).
        /// </summary>
        protected abstract void DoQuery(IWebDriver driver, string query);

        protected abstract bool CheckTitle(string title, string query);

        protected abstract bool CheckUrl(string url);

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
