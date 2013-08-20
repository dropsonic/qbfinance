using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBfinance_auto.Modules
{
    public class BaiduModule : ModuleBase
    {
        public override string Name
        {
            get { return "Baidu"; }
        }

        public override string BaseUrl
        {
            get { return "http://www.baidu.com"; }
        }

        public override void DoQuery(IWebDriver driver, string query)
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IWebElement text = driver.FindElement(By.Id("kw"));
            text.Click();
            text.Clear();
            text.SendKeys(query);
            IWebElement button = driver.FindElement(By.Id("su"));
            button.Click();
        }

        public override bool CheckUrl(string url)
        {
            return true;
        }
    }
}
