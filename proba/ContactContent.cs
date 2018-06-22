using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace proba
{
    [TestClass]
    public class ContactContent
    {
        [TestMethod]
        public void ContactGoesToContact() // Вкладка Contact ведет на страницу Contact
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(3) a")).GetAttribute("href") == "https://contoso-university-demo.azurewebsites.net/contact");
            Dr.Quit();
        }

        [TestMethod]
        public void ContactBanner() // На странице Contact присутствует баннер "Contact"
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/contact");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".container.body-content h2")).Text == "Contact");                                                                                                     
            Dr.Quit();
        }

        [TestMethod]
        public void MarketingEmail() // На странице Contact присутствует почта для сотрудничества
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/contact");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".container.body-content address:nth-last-child(3) a:nth-last-child(1)")).GetAttribute("href") == "mailto:Marketing@example.com");
            Dr.Quit();
        }

        [TestMethod]
        public void SupportEmail() // На странице Contact присутствует почта для поддержки
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/contact");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".container.body-content address:nth-last-child(3) a:nth-last-child(4)")).GetAttribute("href") == "mailto:Support@example.com");
            Dr.Quit();
        }
    }
}
