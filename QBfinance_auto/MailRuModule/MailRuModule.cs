using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBfinance_auto.Modules
{
    public class MailRuModule : ModuleBase
    {
        public override string Name
        {
            get { return "Mail.ru"; }
        }

        public override string BaseUrl
        {
            get { return "http://mail.ru"; }
        }

        public override void DoQuery(IWebDriver driver, string query)
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IWebElement text = driver.FindElement(By.Id("q"));
            text.Click();
            text.Clear();
            text.SendKeys(query);
            IWebElement button = driver.FindElement(By.Id("search__button__wrapper__field"));
            button.Click();
        }
    }
}
