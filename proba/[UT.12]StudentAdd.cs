﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;
using System.Globalization;

namespace proba
{
    [TestClass]
    public class StudentAdd
    {
        string testFirstName = "1TestFirst"; // Значения, чтобы тестовый ученик оказался наверу списка
        string testLastName = "1TestLast";
        string testDate = "1-11-2018"; // M-d-yyyy

        string formatTable = "yyyy-MM-dd"; // Формат даты отображающийся в таблице учеников
        string formatEnter = "M-d-yyyy"; // Формат даты, который требуется при создании ученика
        DateTime parsedDateTimeTable;
        

        [TestMethod]
        public void StudentAddTest() // Добавление студента
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Students");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового ученика
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testLastName); // Заполняем поле Last Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testFirstName); // Заполняем поле First Name           
            Dr.FindElement(By.CssSelector("input#EnrollmentDate.form-control")).SendKeys(testDate + Keys.Enter); // Заполняем поле Enrollment Date           
            Thread.Sleep(2000);
            //Dr.FindElement(By.CssSelector(".col-md-offset-2.col-md-10 input")).Click(); // Нажимаем "Create"
            //Dr.FindElement(By.Name("SearchString")).SendKeys(testFirstName + Keys.Enter); // Поиск по имени
            // Thread.Sleep(1000);         
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(2)")).Text == testFirstName); // Ищем созданного по имени на странице
            string enrollmentDate = Dr.FindElement(By.CssSelector("tbody tr td:nth-child(3)")).Text; // Ищем дату зачисления тестового студента на странице
            parsedDateTimeTable = DateTime.ParseExact(enrollmentDate, formatTable, new CultureInfo("en-US"));         

           
            Assert.IsTrue(parsedDateTimeTable.ToString(formatEnter) == testDate); // Проверка корректнности даты

            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr td:nth-child(1)")).Text == testLastName); // Проверка корректности фамилии

            Dr.FindElement(By.CssSelector(".table a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit();
        }
    }
}
