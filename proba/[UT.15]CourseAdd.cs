using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;

namespace proba
{
    [TestClass]
    public class CourseAdd
    {
        string testNumber = "1"; 
        string testTitle = "1TestTitle";
        string testCredits = "1";
        string testDepartment;

        [TestMethod]
        public void CourseAddTest() // Добавление курса
        {
            IWebDriver Dr;
            Dr = new InternetExplorerDriver();
            Dr.Navigate().GoToUrl("https://contoso-university-demo.azurewebsites.net/Courses");
            Dr.FindElement(By.LinkText("Create New")).Click(); // Нажимаем создать новый курс
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(2) input")).SendKeys(testNumber); // Заполняем поле Number
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(4) input")).SendKeys(testTitle); // Заполняем поле Title         
            Dr.FindElement(By.CssSelector(".form-horizontal div:nth-child(5) input")).SendKeys(testCredits); // Заполняем поле Credits    
            Dr.FindElement(By.TagName("select")).SendKeys(Keys.ArrowDown); // Выбираем факультет
            testDepartment = Dr.FindElement(By.TagName("select")).Text; // Тут весь список факультетов
            string[] tempDep = testDepartment.Split(new char[] { ' ' }); // Добывем нужный факультет
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            Thread.Sleep(1000);
                    
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(1)")).Text == testNumber); // Ищем созданного по Number на странице
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(2)")).Text == testTitle); // Ищем созданного по Title на странице
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(3)")).Text == testCredits); // Ищем созданного по Credits на странице
            Assert.IsTrue(Dr.FindElement(By.CssSelector("tbody tr:nth-last-child(1) td:nth-child(4)")).Text == tempDep[4]); // Ищем созданного по Факультету
            

            Dr.FindElement(By.CssSelector(".table tr:nth-last-child(1) a:nth-child(3)")).Click(); // Чистим за собой
            Dr.FindElement(By.CssSelector("input.btn.btn-default")).Click(); // Подтверждение удаления            
            Dr.Quit();
        }
    }
}
