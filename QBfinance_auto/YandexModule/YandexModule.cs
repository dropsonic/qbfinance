using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QBfinance_auto.Modules
{
    public class YandexModule : ModuleBase
    {
        public override string Name
        {
            get
            {
                return "Яндекс";
            }
        }

        public override string BaseUrl
        {
            get
            {
                return "http://yandex.ru";
            }
        }

        public override void DoQuery(IWebDriver driver, string query)
        {
            //string query_utf8 = Encoding.UTF8.GetString(Encoding.ASCII.GetBytes(query));
            //string query_unicode = Encoding.Unicode.GetString(Encoding.ASCII.GetBytes(query));
            driver.Navigate().GoToUrl(BaseUrl);
            IWebElement text = driver.FindElement(By.Id("text"));
            text.Click();
            text.Clear();
            text.SendKeys(query);
            IWebElement button = driver.FindElement(By.CssSelector("input.b-form-button__input"));
            button.Click();
        }

        public override bool CheckTitle(string title, string query)
        {
            return title != "Ой!";//title.Contains(query);
        }

        public override bool CheckUrl(string url)
        {
            return url.Contains("yandsearch");
        }
    }
}
