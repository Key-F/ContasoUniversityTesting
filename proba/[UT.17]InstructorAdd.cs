using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;
using System.Globalization;

namespace proba
{
    [TestClass]
    public class InstructorAdd
    {
        
            string testFirstName = "1TestFirst"; // Значения, чтобы тестовый преподователь оказался наверу списка
            string testLastName = "1TestLast";
            string testDate = "1-11-2018"; // M-d-yyyy
            string testOfficeLocation = "1TestLocation";

            string formatTable = "yyyy-MM-dd"; // Формат даты отображающийся в таблице преподователей
            string formatEnter = "M-d-yyyy"; // Формат даты, который требуется при создании преподавателя
            DateTime parsedDateTimeTable;


            [TestMethod]
            public void InstructorAddTest() // Добавление преподавателя
            {
                IWebDriver Dr;
                Dr = new InternetExplorerDriver();
                Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Instructors");
                Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового ученика
                Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
                Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
                Dr.FindElement(By.CssSelector("input#HireDate.form-control")).SendKeys(testDate); // Заполняем поле Hire Date        
                Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(6) input")).SendKeys(testOfficeLocation + Keys.Enter); // Заполняем поле Office Location
                // Так как курсов может не существовать вообще, их я трогать не буду
                Thread.Sleep(1000);

                Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == testFirstName); // Ищем созданного по имени на странице
                string enrollmentDate = Dr.FindElement(By.CssSelector("tbody tr td:nth-child(3)")).Text; // Ищем дату дату принятия на работу на странице
                parsedDateTimeTable = DateTime.ParseExact(enrollmentDate, formatTable, new CultureInfo("en-US"));


                Assert.IsTrue(parsedDateTimeTable.ToString(formatEnter) == testDate); // Проверка корректнности даты

                Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(1)")).Text == testLastName); // Проверка корректности фамилии
                Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(4)")).Text == testOfficeLocation); // Проверка корректности офиса
                Dr.FindElement(By.CssSelector(".table a:nth-child(4)")).Click(); // Чистим за собой
                Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
                Dr.Quit();
            }
        
    }
}
