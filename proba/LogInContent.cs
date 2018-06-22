using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace proba
{
    [TestClass]
    public class LogInContent
    {
        [TestMethod]
        public void LogInGoesLogIn() // Вкладка Log in ведет на страницу Log in
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".nav.navbar-nav.navbar-right li:nth-last-child(1) a")).GetAttribute("href") == "https://contoso-university-demo.azurewebsites.net/Account/Login");
            Dr.Quit();
        }

        [TestMethod]
        public void LogInBanner() // На странице Log in присутствует баннер "Log In"
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Account/Login");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".container.body-content h2")).Text == "Log in");
            Dr.Quit();
        }

        [TestMethod]
        public void LogInForm() // На странице Log in присутствует форма для регистрации
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Account/Login");
            Assert.IsTrue(Dr.FindElements(By.CssSelector(".form-control")).Count == 2); // Проверяем, все ли поля ввода на месте
            Assert.IsNotNull(Dr.FindElement(By.CssSelector(".col-md-offset-2.col-md-10 button"))); // Проверяем, существует ли кнопка Log In
            Dr.Quit();
        }

        [TestMethod]
        public void GoogleLogIn() // На странице Log in присутствет кнопка входа через Google 
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Account/Login");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".col-md-4 button:nth-child(1)")).GetAttribute("value") == "Google"); // Проверяем, есть ли кнопка для входа через Google           
            Dr.Quit();
        }

        [TestMethod]
        public void FasebookLogIn() // На странице Log in присутствет кнопка входа через Facebook
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Account/Login");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".col-md-4 button:nth-child(2)")).GetAttribute("value") == "Facebook"); // Проверяем, есть ли кнопка для входа через Facebook           
            Dr.Quit();
        }
    }
}
