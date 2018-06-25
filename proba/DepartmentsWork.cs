using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;

namespace proba
{
    [TestClass]
    public class DepartmentsWork
    {

        string testName = "1TestName"; // Значения, чтобы тестовый ученик оказался наверу списка
        string testBudget = "322";
        string testDate = "1-11-1990"; // M-d-yyyy

        string formatTable = "yyyy-MM-dd"; // Формат даты отображающийся в таблице факультетов
        string formatEnter = "M-d-yyyy"; // Формат даты, который требуется при создании факультета
        DateTime parsedDateTimeTable;

        [TestMethod]
        public void DepartmentNameEditTest() // Изменяем название курса
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Departments");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового факультета
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testName); // Заполняем поле Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testBudget); // Заполняем поле Budget           
            Dr.FindElement(By.CssSelector("input#StartDate.form-control")).SendKeys(testDate + Keys.Enter); // Заполняем поле Start Date        
            Dr.FindElement(By.TagName("select")).SendKeys(Keys.ArrowDown); // Выбираем преподавателя            
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждаем
            Thread.Sleep(1000);

            if (Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(1)")).Text == testName) // Если это наш тестовый факультет
            {
                Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(5) a")).Click(); // Нажимаем Edit
                Dr.FindElement(By.Id("Name")).SendKeys("Test" + Keys.Enter); // Изменяем поле Name               
            }
            // Dr.FindElement(By.Name("SearchString")).SendKeys(testFirstName + Keys.Enter); // Поиск по имени
            Thread.Sleep(1000);
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(1)")).Text == (testName + "Test")); // Ищем Name на странице

            Dr.FindElement(By.CssSelector(".table tr:nth-last-child(1) a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit();
        }
        /*
        [TestMethod]
        public void CourseDepartmentEditTest() // Изменяем Department
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Courses");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать новый курс
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testNumber); // Заполняем поле Number
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testTitle); // Заполняем поле Title         
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(5) input")).SendKeys(testCredits); // Заполняем поле Credits    
            Dr.FindElement(By.TagName("select")).SendKeys(Keys.ArrowDown); // Выбираем факультет  
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждаем
            Thread.Sleep(1000);

            if (Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(1)")).Text == testNumber) // Если это наш тестовый курс
            {
                Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(5) a")).Click(); // Нажимаем Edit
                Dr.FindElement(By.TagName("select")).SendKeys(Keys.ArrowDown); // Меняем факультет   
                testDepartment = Dr.FindElement(By.TagName("select")).Text; // Тут весь список факультетов   
                Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждаем
            }
            string[] tempDep = testDepartment.Split(new char[] { ' ' }); // Добывем нужный факультет             
            Thread.Sleep(1000);
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(4)")).Text == tempDep[5]); // Ищем Department на странице

            Dr.FindElement(By.CssSelector(".table tr:nth-last-child(1) a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit();
        }

        [TestMethod]
        public void CourseCreditsEditTest() // Изменяем Credits
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Courses");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать новый курс
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testNumber); // Заполняем поле Number
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testTitle); // Заполняем поле Title         
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(5) input")).SendKeys(testCredits); // Заполняем поле Credits    
            Dr.FindElement(By.TagName("select")).SendKeys(Keys.ArrowDown); // Выбираем факультет   
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждаем
            Thread.Sleep(1000);

            if (Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(1)")).Text == testNumber) // Если это наш тестовый курс
            {
                Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(5) a")).Click(); // Нажимаем Edit
                Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(6) input")).Clear();
                Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(6) input")).SendKeys("4" + Keys.Enter); // Изменяем поле Credits                
            }
            // Dr.FindElement(By.Name("SearchString")).SendKeys(testFirstName + Keys.Enter); // Поиск по имени
            Thread.Sleep(1000);

            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(3)")).Text == ("4")); // Ищем Credits на странице

            Dr.FindElement(By.CssSelector(".table tr:nth-last-child(1) a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit();
        }

        [TestMethod]
        public void StudentDetailsTest() // Коррекность данных в Details
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            bool Err = false;
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Courses");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать новый курс
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testNumber); // Заполняем поле Number
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testTitle); // Заполняем поле Title         
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(5) input")).SendKeys(testCredits); // Заполняем поле Credits    
            Dr.FindElement(By.TagName("select")).SendKeys(Keys.ArrowDown); // Выбираем факультет 
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждаем
            Thread.Sleep(1000);

            if (Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(1)")).Text == testNumber) // Если это наш тестовый курс
                try
                {
                    Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(5) a:nth-last-child(2)")).Click(); // Нажимаем Details
                    Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click();
                }
                catch
                {
                    Err = true;
                }
            // Страница недоступна, нет возможности протестировать

            Dr.FindElement(By.CssSelector(".table tr:nth-last-child(1) a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit();
            Assert.IsTrue(Err);
        }

        [TestMethod]
        public void CourseDeleteTest() // Коррекность удаления курса
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            bool Boo; // Индикатор отсутствия
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Courses");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать новый курс
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testNumber); // Заполняем поле Number
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testTitle); // Заполняем поле Title         
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(5) input")).SendKeys(testCredits); // Заполняем поле Credits    
            Dr.FindElement(By.TagName("select")).SendKeys(Keys.ArrowDown); // Выбираем факультет  
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждаем
            Thread.Sleep(1000);

            if (Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(1)")).Text == testNumber) // Если это наш тестовый курс  
            {
                Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(5) a:nth-last-child(1)")).Click(); // Нажимаем Delete 
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
            Thread.Sleep(1000);
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(2)")).Text != (testTitle) || Boo); // Ищем Title не равен нашему или курсов не осталось

            Dr.FindElement(By.CssSelector(".table tr:nth-last-child(1) a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit(); 
        }*/
    }
}
