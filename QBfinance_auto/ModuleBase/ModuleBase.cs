using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QBfinance_auto.Modules
{
    public abstract class ModuleBase
    {
        /// <summary>
        /// Название модуля.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Адрес поисковой страницы сайта.
        /// </summary>
        public abstract string BaseUrl { get; }

        /// <summary>
        /// Метод, определяющий логику действий на странице (ввод поискового запроса, нажатие кнопок и т.д.).
        /// </summary>
        public abstract void DoQuery(IWebDriver driver, string query);

        /// <summary>
        /// Метод для проверки заголовка страницы на капчу и т.п.
        /// </summary>
        public abstract bool CheckTitle(string title, string query);

        /// <summary>
        /// Метод для проверки адреса страницы на капчу и т.п.
        /// </summary>
        public abstract bool CheckUrl(string url);

        public override string ToString()
        {
            return Name;
        }
    }
}
