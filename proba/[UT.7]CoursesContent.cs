using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace proba
{
    [TestClass]
    public class CoursesContent
    {
        [TestMethod]
        public void CoursesGoesToCourses() // Вкладка Courses ведет на страницу Courses
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(3) a")).GetAttribute("href") == "https://contoso-university-demo.azurewebsites.net/Courses");
            Dr.Quit();
        }

        [TestMethod]
        public void CoursesBanner() // На странице Courses присутствует баннер "Courses"
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Courses");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".container.body-content h2")).Text == "Courses"); //                                                                                                   
            Dr.Quit();
        }

        [TestMethod]
        public void CoursesTable() // На странице Students присутствует таблица
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Courses");
            Assert.IsNotNull(Dr.FindElement(By.CssSelector(".container.body-content table"))); // Проверяем, существует ли таблица  
            Dr.Quit();
        }
    }
}
