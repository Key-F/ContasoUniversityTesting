using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace proba
{
    [TestClass]
    public class RegisterContent
    {
        [TestMethod]
        public void RegisterGoesRegister() // Вкладка Register ведет на страницу Register
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".nav.navbar-nav.navbar-right li:nth-last-child(2) a")).GetAttribute("href") == "https://contoso-university-demo.azurewebsites.net/Account/Register");
            Dr.Quit();
        }

        [TestMethod]
        public void RegisterBanner() // На странице Register присутствует баннер "Register"
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Account/Register");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".container.body-content h2")).Text == "Register");                                                                                               
            Dr.Quit();
        }

        [TestMethod]
        public void RegisterTable() // На странице  Register присутствует форма для регистрации
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Account/Register");
            Assert.IsTrue(Dr.FindElements(By.CssSelector(".form-control")).Count == 3); // Проверяем, все ли поля ввода на месте
            Assert.IsNotNull(Dr.FindElement(By.CssSelector(".col-md-offset-2.col-md-10 button"))); // Проверяем, существует ли кнопка регистрации
            Dr.Quit();
        }
    }
}
