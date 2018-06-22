using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;

namespace proba
{
    [TestClass]
    public class StudentAdd
    {
        string testFirstName = "TestFirst";
        string testLastName = "TestLast";
        string testDate = "15-11-2018"; //

        [TestMethod]
        public void LogInBanner() // На странице Log in присутствует баннер "Log In"
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Students");
            Dr.FindElement(By.LinkText("Create New")).Click();
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#EnrollmentDate.form-control")).SendKeys(testDate + Keys.Enter); // Заполняем поле Enrollment Date           
            Thread.Sleep(1000);
            //Dr.FindElement(By.CssSelector(".col-md-offset-2.col-md-10 input")).Click(); // Нажимаем "Create"
            Dr.FindElement(By.Name("SearchString")).SendKeys(testFirstName + Keys.Enter); // Поиск по имени
            Thread.Sleep(1000);         
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == testFirstName); // Ищем созданного по имени
            Dr.FindElement(By.CssSelector(".table a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit();
        }
    }
}
