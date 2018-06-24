using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;
using System.Globalization;

namespace proba
{
    [TestClass]
    public class DepartmentAdd
    {
        string testName = "1TestName"; // Значения, чтобы тестовый ученик оказался наверу списка
        string testBudget = "322";
        string testDate = "1-11-1990"; // M-d-yyyy

        string formatTable = "yyyy-MM-dd"; // Формат даты отображающийся в таблице факультетов
        string formatEnter = "M-d-yyyy"; // Формат даты, который требуется при создании факультета
        DateTime parsedDateTimeTable;


        [TestMethod]
        public void DepartmentAddTest() // Добавление факультета
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Departments");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать нового факультета
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testName); // Заполняем поле Name
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testBudget); // Заполняем поле Budget           
            Dr.FindElement(By.CssSelector("input#StartDate.form-control")).SendKeys(testDate + Keys.Enter); // Заполняем поле Start Date        
            Dr.FindElement(By.TagName("select")).SendKeys(Keys.ArrowDown); // Выбираем преподавателя
            string InstrID = Dr.FindElement(By.TagName("select")).Text; // Тут весь список преподавателей
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            string[] tempIns = InstrID.Split(new char[] { ' ' }); // Добывем нужного преподавателя
            Thread.Sleep(1000);
            //Dr.FindElement(By.CssSelector(".col-md-offset-2.col-md-10 input")).Click(); // Нажимаем "Create"
            //Dr.FindElement(By.Name("SearchString")).SendKeys(testFirstName + Keys.Enter); // Поиск по имени
            // Thread.Sleep(1000);         
            
            string startDate = Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(3)")).Text; // Ищем дату на странице
            parsedDateTimeTable = DateTime.ParseExact(startDate, formatTable, new CultureInfo("en-US"));
           
            Double budgetInTable = double.Parse(Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(2)")).Text, new CultureInfo("en-us"));
            // Convert.ToSingle(Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(2)")).Text); // Как бюджет отображается на странице
            Double dTestBudget = double.Parse(testBudget, new CultureInfo("en-us"));
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(1)")).Text == testName); // Ищем созданного по Name на странице
            Assert.IsTrue(budgetInTable == dTestBudget); // Ищем созданного по Budget на странице, конвертируем, тк отображается дробная часть
            Assert.IsTrue(parsedDateTimeTable.ToString(formatEnter) == testDate); // Ищем созданного по Start Date на странице
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(4)")).Text.Contains(tempIns[4])); // Ищем созданного по Администратору


            Dr.FindElement(By.CssSelector(".table tr:nth-last-child(1) a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления                    
            Dr.Quit();
        }
    }
}
