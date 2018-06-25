using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace proba
{
    [TestClass]
    public class DepartmentsContent
    {
        [TestMethod]
        public void DepartmentsGoesDepartments() // Вкладка Departments ведет на страницу Departments
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".dropdown-menu li:nth-last-child(1) a")).GetAttribute("href") == "https://contoso-university-demo.azurewebsites.net/Departments");
            Dr.Quit();
        }

        [TestMethod]
        public void DepartmentsBanner() // На странице Departments присутствует баннер "Departments"
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Departments");
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".container.body-content h2")).Text == "Departments"); //                                                                                                   
            Dr.Quit();
        }

        [TestMethod]
        public void DepartmentsTable() // На странице Departments присутствует таблица
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Departments");
            Assert.IsNotNull(Dr.FindElement(By.CssSelector(".container.body-content table"))); // Проверяем, существует ли таблица  
            Dr.Quit();
        }
    }
}
