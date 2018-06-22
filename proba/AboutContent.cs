using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace proba
{
    [TestClass]
    public class AboutContent
    {
        [TestMethod]
        public void AboutGoesToAbout() // Вкладка About ведет на страницу About
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(2) a")).GetAttribute("href") == "https://contoso-university-demo.azurewebsites.net/about");
            Dr.Quit();
        }

        [TestMethod]
        public void AboutBanner() // На странице About присутствует баннер "Students Body Statistics"
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/about");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".container.body-content h2")).Text.StartsWith("Student Body Statistics")); // В данном случае точка на конце не будет считаться несоответсвием                                                                                                     
            Dr.Quit();
        }

        [TestMethod]
        public void AboutTable() // На странице about присутствует таблица
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/about");
            Assert.IsNotNull(Dr.FindElement(By.CssSelector(".container.body-content table"))); // Проверяем, существует ли таблица      
            List<IWebElement> ElementsOfTable = Dr.FindElements(By.CssSelector(".container.body-content tr")).ToList(); // vrode rabotaet

            Assert.IsTrue(ElementsOfTable[0].Text == "Enrollment Date Students"); // Заголовок таблицы
            
            string[] formats = { "M/d/yyyy" }; // Формат даты
            DateTime parsedDateTime;
            
            for (int i = 1; i < ElementsOfTable.Count; i++)
            {
                string[] temp = ElementsOfTable[i].Text.Split(new char[] { ' ' }); // Делим на дату и на количество студентов
                Assert.IsTrue(DateTime.TryParseExact(temp[0], formats, new CultureInfo("en-US"),
                                           DateTimeStyles.None, out parsedDateTime)); // Первая часть соответсвует формату даты
                Assert.IsNotNull(Convert.ToInt32(temp[1])); // Вторая часть является числом
            }

            Dr.Quit();
        }
    }
}
