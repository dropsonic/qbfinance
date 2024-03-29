﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QBfinance_auto.Modules
{
    public class GoogleModule : ModuleBase
    {
        public override string Name
        {
            get 
            {
                return "Google";
            }
        }

        public override string BaseUrl
        {
            get 
            {
                return "http://google.ru";
            }
        }

        public override void DoQuery(IWebDriver driver, string query)
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IWebElement text = driver.FindElement(By.Id("gbqfq"));
            text.Click();
            text.Clear();
            text.SendKeys(query);

            IWebElement button;
            try
            {
                button = driver.FindElement(By.Id("gbqfba"));
            }
            catch (NoSuchElementException)
            {
                button = driver.FindElement(By.Id("gbqfb"));
            }
            button.Click();
        }

        public override bool CheckUrl(string url)
        {
            return url.Contains("search") && !url.Contains("sorry");
        }
    }
}
