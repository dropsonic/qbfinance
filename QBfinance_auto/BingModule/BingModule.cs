using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QBfinance_auto.Modules
{
    public class BingModule : ModuleBase
    {
        public override string Name
        {
            get { return "Bing"; }
        }

        public override string BaseUrl
        {
            get { return "http://www.bing.com"; }
        }

        public override void DoQuery(IWebDriver driver, string query)
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IWebElement text = driver.FindElement(By.Id("sb_form_q"));
            text.Click();
            text.Clear();
            text.SendKeys(query);
            IWebElement button = driver.FindElement(By.Id("sb_form_go"));
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