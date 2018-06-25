using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace proba
{
    [TestClass]
    public class CUAndHomeContent
    {

        [TestMethod]
        public void CUGoesToHome() // Вкладка Contoso University ведет на домашнюю страницу
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".navbar-brand")).GetAttribute("href") == "https://contoso-university-demo.azurewebsites.net/"); 
            Dr.Quit();
        }

        [TestMethod]
        public void HomeGoesToHome() // Вкладка Home ведет на домашнюю страницу
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(4) a")).GetAttribute("href") == "https://contoso-university-demo.azurewebsites.net/");
            Dr.Quit();
        }
       
        [TestMethod]
        public void ContosoUniversityAndHomeBanner() // На главной странице присутствует баннер с названием университета "Contoso University"
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            //Dr.FindElement(By.CssSelector(".navbar-brand")).Click();
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".jumbotron h1")).Text == "Contoso University"); // Проверяем наличие Названия университета на главной странице  
           // Assert.IsTrue(Dr.FindElement(By.CssSelector(".btn.btn-default")).GetAttribute("href") == "https://docs.asp.net/en/latest/data/ef-mvc/intro.html");
            Dr.Quit();
        }


        [TestMethod]
        public void CUAndHomeCorrectLinkTutorial() // Корректность ссылки на Tutorial
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");              
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".row div:nth-last-child(2) .btn.btn-default")).GetAttribute("href") == "https://docs.asp.net/en/latest/data/ef-mvc/intro.html");
            Dr.Quit();
        }

        [TestMethod]
        public void CUAndHomeCorrectLinkSourceCode() // Корректность ссылки на Source Code
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".row div:nth-last-child(1) .btn.btn-default")).GetAttribute("href") == "https://github.com/alimon808/contoso-university");
            Dr.Quit();
        }
    }
}
