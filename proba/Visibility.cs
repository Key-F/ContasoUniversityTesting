using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;

namespace proba
{
    [TestClass]
    public class Visibility
    {
        [TestMethod]
        public void TestMethod1()
        {

            IWebDriver Dr;

            //var options = new InternetExplorerOptions();
            //options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            Dr = new InternetExplorerDriver();  
            
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            //Thread.Sleep(10000);
            //Dr.Navigate().GoToUrl("http://myanimeshelf.com/shelf/Key_F");
            //Thread.Sleep(10000);
            //  IWebElement SearchLoginButton = Dr.FindElement(By.ClassName("logInButt"));
            // Dr.FindElement(By.ClassName("navbar-brand"));
            //Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(1) a")).Click(); // Открыть всплывающий список
            
             //Assert.IsNotNull(Dr.FindElement(By.CssSelector(".navbar-nav.navbar-right")).Displayed);
            Assert.IsNotNull(Dr.FindElement(By.CssSelector(".navbar-nav.navbar-right")).Displayed);
            Dr.Quit();
        }

        [TestMethod]
        public void ContosoUniversityVisibility()
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".navbar-brand")).Displayed);
            Dr.Quit();
        }

        [TestMethod] 
        public void HomeVisibility() // Home
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            //Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(4) a")).Click();
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(4) a")).Displayed);
            Dr.Quit();
        }

        [TestMethod]
        public void ContactVisibility() // Contact
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
           // Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(3) a")).Click();
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(3) a")).Displayed);
            Dr.Quit();
        }

        [TestMethod]
        public void AboutVisibility() // About
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            //Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(2) a")).Click();
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(3) a")).Displayed);
            Dr.Quit();
        }

        [TestMethod]
        public void DepartmentsVisibility() // Departments
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
           
            Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(1) a")).Click(); // Открыть всплывающий список
            //Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(1) a")).Click();
           Assert.IsTrue(Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(1) a")).Displayed);
            Dr.Quit();
        }

        [TestMethod]
        public void InstructorsVisibility() // Instructors
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");

            Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(1) a")).Click(); // Открыть всплывающий список
            //Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(1) a")).Click();
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(2) a")).Displayed);
            Dr.Quit();
        }

        [TestMethod]
        public void CoursesVisibility() // Courses
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");

            Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(1) a")).Click(); // Открыть всплывающий список
            //Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(2) a")).Click();
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(3) a")).Displayed);
            Dr.Quit();
        }

        [TestMethod]
        public void StudentsVisibility() // Students
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");

            Dr.FindElement(By.CssSelector(".nav.navbar-nav li:nth-last-child(1) a")).Click(); // Открыть всплывающий список
            //Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(2) a")).Click();
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(4) a")).Displayed);
            Dr.Quit();
        }

        [TestMethod]
        public void RegisterVisibility() // Register
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");

           // Dr.FindElement(By.CssSelector(".nav.navbar-nav.navbar-right li:nth-last-child(2) a ")).Click(); 
            //Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(1) a")).Click();
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".nav.navbar-nav.navbar-right li:nth-last-child(2) a")).Displayed);
            Dr.Quit();
        }

        [TestMethod]
        public void LoginVisibility() // Log in
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");

            // Dr.FindElement(By.CssSelector(".nav.navbar-nav.navbar-right li:nth-last-child(2) a ")).Click(); 
            //Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(1) a")).Click();
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".nav.navbar-nav.navbar-right li:nth-last-child(1) a")).Displayed);
            Dr.Quit();
        }
    }
}
