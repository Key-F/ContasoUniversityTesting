using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.IE;

namespace proba
{
    [TestClass]
    public class StudentsWork
    {
        string testFirstName = "1TestFirst";
        string testLastName = "1TestLast";
        string testDate = "1-11-2018"; // M-d-yyyy

        [TestMethod]
        public void StudentLastNameEditTest() // Изменяем имя ученика
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Students");        
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового ученика
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#EnrollmentDate.form-control")).SendKeys(testDate + Keys.Enter); // Заполняем поле Enrollment Date           
            Thread.Sleep(1000);
            
            if (Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == testFirstName) // Если это наш тестовый ученик
            {
                Dr.FindElement(By.CssSelector("tbody tr td:nth-child(4) a:nth-child(1)")).Click();
                Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys("Test" + Keys.Enter); // Изменяем поле Last Name                 
            }
           // Dr.FindElement(By.Name("SearchString")).SendKeys(testFirstName + Keys.Enter); // Поиск по имени
            Thread.Sleep(1000);
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(1)")).Text == (testLastName + "Test")); // Ищем фамилию на странице
            Dr.FindElement(By.CssSelector(".table a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit();
        }

        [TestMethod]
        public void StudentFirstNameEditTest() // Изменяем Фамилию
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Students");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового ученика
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#EnrollmentDate.form-control")).SendKeys(testDate + Keys.Enter); // Заполняем поле Enrollment Date           
            Thread.Sleep(1000);

            if (Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == testFirstName) // Если это наш тестовый ученик
            {
                Dr.FindElement(By.CssSelector("tbody tr td:nth-child(4) a:nth-child(1)")).Click();
               
                Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(5) input")).SendKeys("Test" + Keys.Enter); // Изменяем поле First Name           
                //Dr.FindElement(By.CssSelector("input#EnrollmentDate.form-control")).SendKeys(testDate + Keys.Enter); // Заполняем поле Enrollment Date       
            }
            // Dr.FindElement(By.Name("SearchString")).SendKeys(testFirstName + Keys.Enter); // Поиск по имени
            Thread.Sleep(1000);
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == (testFirstName + "Test")); // Ищем имя на странице
            Dr.FindElement(By.CssSelector(".table a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit();
        }
    }
}
