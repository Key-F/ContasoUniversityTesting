using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace proba
{
    [TestClass]
    public class Acessibility
    {
        [TestMethod]
        public void ContosoUniversityAcessibility() // Contoso University
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Dr.FindElement(By.CssSelector(".navbar-brand")).Click();
            Assert.IsFalse(Dr.Title.Contains("404") || Dr.Title.Contains("Not found")); // Проверяем наличие "404" в заголовке страницы          
            Dr.Quit();
        }

        [TestMethod]
        public void HomeAcessibility() // Home
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(4) a")).Click();
            Assert.IsFalse(Dr.Title.Contains("404") || Dr.Title.Contains("Not found"));
            Dr.Quit();
        }

        [TestMethod]
        public void ContactAcessibility() // Contact
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(3) a")).Click();
            Assert.IsFalse(Dr.Title.Contains("404") || Dr.Title.Contains("Not found"));
            Dr.Quit();
        }

        [TestMethod]
        public void AboutAcessibility() // About
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(2) a")).Click();
            Assert.IsFalse(Dr.Title.Contains("404") || Dr.Title.Contains("Not found"));
            Dr.Quit();
        }

        [TestMethod]
        public void DepartmentsAcessibility() // Departments
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(1) a")).Click(); // Открыть всплывающий список
            Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(1) a")).Click(); // Выбрать нижний элемент списка
            Assert.IsFalse(Dr.Title.Contains("404") || Dr.Title.Contains("Not found"));
            Dr.Quit();
        }

        [TestMethod]
        public void InstructorsAcessibility() // Instructors
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(1) a")).Click(); // Открыть всплывающий список
            Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(2) a")).Click();
            Assert.IsFalse(Dr.Title.Contains("404") || Dr.Title.Contains("Not found"));
            Dr.Quit();
        }

        [TestMethod]
        public void CoursesAcessibility() // Courses
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(1) a")).Click(); // Открыть всплывающий список
            Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(3) a")).Click(); // Нажимаем на Courses
            Assert.IsFalse(Dr.Title.Contains("404") || Dr.Title.Contains("Not found"));
            Dr.Quit();
        }

        [TestMethod]
        public void StudentsAcessibility() // Students
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(1) a")).Click(); // Открыть всплывающий список
            Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(4) a")).Click();
            Assert.IsFalse(Dr.Title.Contains("404") || Dr.Title.Contains("Not found"));
            Dr.Quit();
        }

        [TestMethod]
        public void RegisterAcessibility() // Register
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Dr.FindElement(By.CssSelector(".nav.navbar-nav.navbar-right li:nth-last-child(2) a")).Click();
            Assert.IsFalse(Dr.Title.Contains("404") || Dr.Title.Contains("Not found"));
            Dr.Quit();
        }

        [TestMethod]
        public void LoginAcessibility() // Log in
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Dr.FindElement(By.CssSelector(".nav.navbar-nav.navbar-right li:nth-last-child(1) a")).Click();
            Assert.IsFalse(Dr.Title.Contains("404") || Dr.Title.Contains("Not found"));
            Dr.Quit();
        }
    }
}
