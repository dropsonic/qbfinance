using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBfinance_auto.Modules
{
    public class YahooModule : ModuleBase
    {
        public override string Name
        {
            get { return "Yahoo!"; }
        }

        public override string BaseUrl
        {
            get { return "http://ru.yahoo.com"; }
        }

        public override void DoQuery(IWebDriver driver, string query)
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IWebElement text = driver.FindElement(By.Id("mediafpwave3-p"));
            text.Click();
            text.Clear();
            text.SendKeys(query);
            IWebElement button = driver.FindElement(By.Id("search-submit"));
            button.Click();
        }

        public override bool CheckTitle(string title, string query)
        {
            return title.Contains(query);
        }

        public override bool CheckUrl(string url)
        {
            return url.Contains("search");
        }
    }
}
