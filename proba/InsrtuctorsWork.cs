using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.IE;
using System.Globalization;

namespace proba
{
    [TestClass]
    public class InsrtuctorsWork
    {

        string testFirstName = "1TestFirst"; // Значения, чтобы тестовый преподователь оказался наверу списка
        string testLastName = "1TestLast";
        string testDate = "1-11-2018"; // M-d-yyyy
        string testOfficeLocation = "1TestLocation";

        string formatTable = "yyyy-MM-dd"; // Формат даты отображающийся в таблице преподователей
        string formatEnter = "M-d-yyyy"; // Формат даты, который требуется при создании преподавателя
        DateTime parsedDateTimeTable;

        [TestMethod]
        public void InstructorLastNameEditTest() // Изменяем фамилию преподавателя
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Instructors");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового преподавателя
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#HireDate.form-control")).SendKeys(testDate); // Заполняем поле Hire Date        
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(6) input")).SendKeys(testOfficeLocation + Keys.Enter); // Заполняем поле Office Location
            Thread.Sleep(1000);

            if (Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == testFirstName) // Если это наш тестовый преподаватель
            {
                Dr.FindElement(By.CssSelector(".table a:nth-child(2)")).Click(); // Нажимаем Edit
                Dr.FindElement(By.Id("LastName")).SendKeys("Test" + Keys.Enter); // Изменяем поле LastName               
            }

            Thread.Sleep(2000);
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(1)")).Text == (testLastName + "Test")); // Ищем LastName на странице

            Dr.FindElement(By.CssSelector(".table a:nth-child(4)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления          
            Dr.Quit();
        }

        [TestMethod]
        public void InstructorFirstNameEditTest() // Изменяем имя преподавателя
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Instructors");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового преподавателя
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#HireDate.form-control")).SendKeys(testDate); // Заполняем поле Hire Date        
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(6) input")).SendKeys(testOfficeLocation + Keys.Enter); // Заполняем поле Office Location
            Thread.Sleep(1000);

            if (Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == testFirstName) // Если это наш тестовый преподаватель
            {
                Dr.FindElement(By.CssSelector(".table a:nth-child(2)")).Click(); // Нажимаем Edit
                Dr.FindElement(By.Id("FirstMidName")).SendKeys("Test" + Keys.Enter); // Изменяем поле LastName               
            }

            Thread.Sleep(2000);
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == (testFirstName + "Test")); // Ищем FirstName на странице

            Dr.FindElement(By.CssSelector(".table a:nth-child(4)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления          
            Dr.Quit();
        }

        [TestMethod]
        public void HireDateEditTest() // Изменяем дату принятия на работу
        {
            string newHireDate = "2-10-1989";
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Instructors");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового преподавателя
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#HireDate.form-control")).SendKeys(testDate); // Заполняем поле Hire Date        
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(6) input")).SendKeys(testOfficeLocation + Keys.Enter); // Заполняем поле Office Location
            Thread.Sleep(1000);

            if (Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == testFirstName) // Если это наш тестовый преподаватель
            {
                Dr.FindElement(By.CssSelector(".table a:nth-child(2)")).Click(); // Нажимаем Edit
                Dr.FindElement(By.Id("HireDate")).Clear(); // Отчищаем поле
                Dr.FindElement(By.Id("HireDate")).SendKeys(newHireDate + Keys.Enter);
            }

            Thread.Sleep(2000);
            string enrollmentDate = Dr.FindElement(By.CssSelector("tbody tr td:nth-child(3)")).Text; // Ищем дату дату принятия на работу на странице
            parsedDateTimeTable = DateTime.ParseExact(enrollmentDate, formatTable, new CultureInfo("en-US"));

            Assert.IsTrue(parsedDateTimeTable.ToString(formatEnter) == newHireDate); // Проверка корректнности даты
            Dr.FindElement(By.CssSelector(".table a:nth-child(4)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления          
            Dr.Quit();
        }

        [TestMethod]
        public void InstructorOfficeLocationEditTest() // Изменяем место офиса
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Instructors");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового преподавателя
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#HireDate.form-control")).SendKeys(testDate); // Заполняем поле Hire Date        
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(6) input")).SendKeys(testOfficeLocation + Keys.Enter); // Заполняем поле Office Location
            Thread.Sleep(1000);

            if (Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == testFirstName) // Если это наш тестовый преподаватель
            {
                Dr.FindElement(By.CssSelector(".table a:nth-child(2)")).Click(); // Нажимаем Edit
                Dr.FindElement(By.Id("OfficeAssignment_Location")).SendKeys("Test" + Keys.Enter); // Изменяем поле LastName               
            }

            Thread.Sleep(2000);
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(4)")).Text == (testOfficeLocation + "Test")); // Ищем OfficeLocation на странице

            Dr.FindElement(By.CssSelector(".table a:nth-child(4)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления          
            Dr.Quit();
        }

        [TestMethod]
        public void InstructorDetailsTest() // Проверяем корректность Details
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Instructors");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового преподавателя
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#HireDate.form-control")).SendKeys(testDate); // Заполняем поле Hire Date        
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(6) input")).SendKeys(testOfficeLocation + Keys.Enter); // Заполняем поле Office Location
            Thread.Sleep(1000);

            if (Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == testFirstName) // Если это наш тестовый преподаватель            
                Dr.FindElement(By.CssSelector(".table a:nth-child(3)")).Click(); // Нажимаем Details          
            Thread.Sleep(2000);


           

            Assert.IsTrue(Dr.FindElement(By.CssSelector(".dl-horizontal dd:nth-child(2)")).Text == testLastName); // Сверяем фамлию
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".dl-horizontal dd:nth-child(4)")).Text == testFirstName); // Сверяем имя


            string Date = Dr.FindElement(By.CssSelector(".dl-horizontal dd:nth-child(6)")).Text; // Ищем нужную дату
            parsedDateTimeTable = DateTime.ParseExact(Date, "yyyy-MM-dd", new CultureInfo("en-US"));
            Assert.IsTrue(parsedDateTimeTable.ToString(formatEnter) == testDate); ; // Сверяем дату
            

            Dr.FindElement(By.CssSelector(".container.body-content a:nth-child(2)")).Click(); // Back to List

            Dr.FindElement(By.CssSelector(".table a:nth-child(4)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления          
            Dr.Quit();
        }

        [TestMethod]
        public void InstructorDeleteTest() // Проверяем корректность Delete
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            bool Boo; // Флаг наличия
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Instructors");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового преподавателя
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#HireDate.form-control")).SendKeys(testDate); // Заполняем поле Hire Date        
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(6) input")).SendKeys(testOfficeLocation + Keys.Enter); // Заполняем поле Office Location
            Thread.Sleep(1000);

            if (Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == testFirstName) // Если это наш тестовый преподаватель    
            {
                Dr.FindElement(By.CssSelector(".table a:nth-child(4)")).Click(); // Нажимаем Details          
                Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления 
            }

            Thread.Sleep(2000);

            try
            {
                Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")); // Есть ли записи
                Boo = false;
            }
            catch (NoSuchElementException e)
            {
                Boo = true;
            }
            Thread.Sleep(1000);
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text != (testFirstName) || Boo); // Ищем Name не равен нашему или курсов не осталось

            Dr.FindElement(By.CssSelector(".container.body-content a:nth-child(2)")).Click(); // Back to List

                 
            Dr.Quit();
        }

    } 
    
}
