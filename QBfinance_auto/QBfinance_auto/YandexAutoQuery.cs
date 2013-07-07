using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QBfinance_auto
{
    public class YandexAutoQuery : AutoQuery
    {
        public YandexAutoQuery(string baseUrl, string[] proxies, string[] queries,
            int queryInterval, int proxyTimeout, int maxTime, ILogger logger)
            : base(baseUrl, proxies, queries, queryInterval, proxyTimeout, maxTime, logger)
        { }

        protected override void DoQuery(IWebDriver driver, string query)
        {
            string query_utf8 = Encoding.UTF8.GetString(Encoding.ASCII.GetBytes(query));
            driver.Navigate().GoToUrl(BaseUrl);
            IWebElement text = driver.FindElement(By.Id("text"));
            text.Click();
            text.Clear();
            text.SendKeys(query_utf8);
            IWebElement button = driver.FindElement(By.CssSelector("input.b-form-button__input"));
            button.Click();
        }

        protected override bool CheckTitle(string title, string query)
        {
            return title != "Ой!";//title.Contains(query);
        }

        protected override bool CheckUrl(string url)
        {
            return url.Contains("yandsearch");
        }
    }
}
