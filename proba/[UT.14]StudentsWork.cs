﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.IE;
using System.Globalization;

namespace proba
{
    [TestClass]
    public class StudentsWork
    {
        string testFirstName = "1TestFirst";
        string testLastName = "1TestLast";
        string testDate = "1-11-2018"; // M-d-yyyy

        string testDateEdit = "8-6-2017";

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
            
            if (Dr.FindElement(By.CssSelector("tbody tr td:nth-child(1)")).Text == testLastName) // Если это наш тестовый ученик
            {
                Dr.FindElement(By.CssSelector("tbody tr td:nth-child(4) a:nth-child(1)")).Click(); // Нажимаем Edit
                Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys("Test" + Keys.Enter); // Изменяем поле Last Name                 
            }
           // Dr.FindElement(By.Name("SearchString")).SendKeys(testFirstName + Keys.Enter); // Поиск по имени
            Thread.Sleep(2000);
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
                Dr.FindElement(By.CssSelector("tbody tr td:nth-child(4) a:nth-child(1)")).Click(); // Нажимаем Edit

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

        [TestMethod]
        public void StudentEnrollmentDateEditTest() // Изменяем дату зачисления
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Students");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового ученика
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#EnrollmentDate.form-control")).SendKeys(testDate + Keys.Enter); // Заполняем поле Enrollment Date           
            Thread.Sleep(2000);

            if (Dr.FindElement(By.CssSelector("tbody tr td:nth-child(1)")).Text == testLastName) // Если это наш тестовый ученик
            {
                Dr.FindElement(By.CssSelector("tbody tr td:nth-child(4) a:nth-child(1)")).Click(); // Нажимаем Edit

                Dr.FindElement(By.CssSelector("input#EnrollmentDate.form-control")).Clear(); // Отчищаем поле даты
                Dr.FindElement(By.CssSelector("input#EnrollmentDate.form-control")).SendKeys(testDateEdit + Keys.Enter); // Заполняем поле Enrollment Date       
            }
            
            Thread.Sleep(1000);
            string Date = Dr.FindElement(By.CssSelector("tbody tr td:nth-child(3)")).Text; // Ищем нужную дату
            DateTime tableDate = DateTime.ParseExact(Date, "yyyy-MM-dd", new CultureInfo("en-US")); 
            Assert.IsTrue(tableDate.ToString("M-d-yyyy") == testDateEdit); // Сравниваем измененое значение и значение, отображающеся в таблице
            Dr.FindElement(By.CssSelector(".table a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit();
        }

        [TestMethod]
        public void StudentDetailsTest() // Коррекность данных в Details
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
                Dr.FindElement(By.CssSelector("tbody tr td:nth-child(4) a:nth-child(2)")).Click(); // Нажимаем Details

            Assert.IsTrue(Dr.FindElement(By.CssSelector(".dl-horizontal dd:nth-child(2)")).Text == testLastName); // Сверяем фамилию
            Assert.IsTrue(Dr.FindElement(By.CssSelector(".dl-horizontal dd:nth-child(4)")).Text == testFirstName); // Сверяем Имя
            string Date = Dr.FindElement(By.CssSelector(".dl-horizontal dd:nth-child(6)")).Text; // Ищем нужную дату
            DateTime tableDate = DateTime.ParseExact(Date, "yyyy-MM-dd", new CultureInfo("en-US"));
            Assert.IsTrue(tableDate.ToString("M-d-yyyy") == testDate); // Сверяем дату
            Dr.FindElement(By.CssSelector(".container.body-content a:nth-child(2)")).Click(); // Back to List
            Thread.Sleep(1000);
            
            Dr.FindElement(By.CssSelector(".table a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit();
        }

        [TestMethod]
        public void StudentDeleteTest() // Коррекность данных в Details
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            bool Boo; // Индикатор отсутствия
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Students");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового ученика
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName + "Add"); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#EnrollmentDate.form-control")).SendKeys(testDate + Keys.Enter); // Заполняем поле Enrollment Date           
            Thread.Sleep(1000);

            if (Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == testFirstName + "Add") // Если это наш тестовый ученик   
            {
                Dr.FindElement(By.CssSelector("tbody tr td:nth-child(4) a:nth-child(3)")).Click(); // Нажимаем Delete
                Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления 
            }
            try
            {
                Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")); // Есть ли записи
                Boo = false;
            }
            catch (NoSuchElementException e)
            {
                Boo = true;
            }
            Assert.IsTrue((Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text != testFirstName + "Add") || Boo); // Или это не наш ученик или учеников больше нет
            Dr.Quit();
        }
    }
}
