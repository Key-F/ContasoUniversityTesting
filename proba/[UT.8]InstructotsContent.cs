using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace proba
{
    [TestClass]
    public class InstructotsContent
    {
        [TestMethod]
        public void InstructorsGoesToInstructors() // Вкладка Insrtructors ведет на страницу Instructors
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(2) a")).GetAttribute("href") == "https://contoso-university-demo.azurewebsites.net/Instructors");
            Dr.Quit();
        }

        [TestMethod]
        public void InstructorsBanner() // На странице Instructors присутствует баннер "Instructors"
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Instructors");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".container.body-content h2")).Text == "Instructors"); //                                                                                                   
            Dr.Quit();
        }

        [TestMethod]
        public void InstructorsTable() // На странице Instructors присутствует таблица
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Instructors");
            Assert.IsNotNull(Dr.FindElement(By.CssSelector(".container.body-content table"))); // Проверяем, существует ли таблица  
            Dr.Quit();
        }
    }
}
