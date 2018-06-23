using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;

namespace proba
{
    [TestClass]
    public class StudentSearch
    {
        string testFirstName = "TestFirst";
        string testLastName = "TestLast";
        string testDate = "1-11-2018"; // M-d-yyyy

        [TestMethod]
        public void SearchFirstNameTest() // В поле поиска вводим имя ученика
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Students");
            // string testName = Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text;
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового ученика
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#EnrollmentDate.form-control")).SendKeys(testDate + Keys.Enter); // Заполняем поле Enrollment Date           
            Thread.Sleep(1000);
            //Dr.FindElement(By.CssSelector(".col-md-offset-2.col-md-10 input")).Click(); // Нажимаем "Create"
            Dr.FindElement(By.Name("SearchString")).SendKeys(testFirstName + Keys.Enter); // Поиск по имени
            Thread.Sleep(1000);
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(1)")).Text == testLastName); // Ищем созданную фамилию на странице
            Dr.FindElement(By.CssSelector(".table a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit();
        }

        [TestMethod]
        public void SearchLastNameTest() // В поле поиска вводим фамилию ученика
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Students");
            // string testName = Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text;
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового ученика
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#EnrollmentDate.form-control")).SendKeys(testDate + Keys.Enter); // Заполняем поле Enrollment Date           
            Thread.Sleep(1000);
            //Dr.FindElement(By.CssSelector(".col-md-offset-2.col-md-10 input")).Click(); // Нажимаем "Create"
            Dr.FindElement(By.Name("SearchString")).SendKeys(testFirstName + Keys.Enter); // Поиск по фамилии
            Thread.Sleep(1000);
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == testFirstName); // Ищем созданное имя на странице
            Dr.FindElement(By.CssSelector(".table a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit();
        }

        [TestMethod]
        public void SearchNonxistentStudent() // В поле поиска вводим несуществующего
        {
            IWebDriver Dr;
            bool Boo; // Индикатор наличия записи
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Students");
            Dr.FindElement(By.Name("SearchString")).SendKeys(testFirstName + "NonexistendAddition" + Keys.Enter); // Поиск несуществующего
            Thread.Sleep(1000);
            //string ff = Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text;
            try
            {
                Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")); // Есть ли записи
                Boo = true;
            }
            catch (NoSuchElementException e)
            {
                Boo =  false;
            }
            Assert.IsFalse(Boo);                            
            Dr.Quit();
        }

        
    }
}
