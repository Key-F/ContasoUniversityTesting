using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace proba
{
    [TestClass]
    public class StudentsContent
    {
        [TestMethod]
        public void StudentsGoesToStudents() // Вкладка Students ведет на страницу Students
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(4) a")).GetAttribute("href") == "https://contoso-university-demo.azurewebsites.net/Students");
            Dr.Quit();
        }

        [TestMethod]
        public void StudentsBanner() // На странице Students присутствует баннер "Index"
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Students");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".container.body-content h2")).Text == "Index"); //                                                                                                   
            Dr.Quit();
        }

        [TestMethod]
        public void SudentsTable() // На странице Students присутствует таблица
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Students");
            Assert.IsNotNull(Dr.FindElement(By.CssSelector(".container.body-content table"))); // Проверяем, существует ли таблица  
            Dr.Quit();
        }
    }
}
