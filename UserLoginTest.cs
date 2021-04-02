using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{
    [TestFixture]
    public class UserLoginTest: TestFixtureBase
    {
        
        [Test]
        public void UserLoginMultipleWorkspace()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(URL);
            DoLoginAdminMultipleWorkspace();
            Assert.AreEqual(driver.Url, MultipleWorkspaceListPage);
            
        }
        [Test]
        public void UserLoginSingleWorkspace()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(URL);
            DoLoginAdminOneWorkspace();
            Assert.AreEqual(driver.Url, HomePageOneWorkspace);
           
    
        }
        [Test]
        public void UserLoginPortfolio()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(URL);
            DoLoginPortfolio();
            Assert.AreEqual(driver.Url, "");
            
        }
        [Test]
        public void UserLoginInvalidLogin()
        {
           
            driver.FindElement(By.Name("Username")).SendKeys("");
            driver.FindElement(By.Name("Password")).SendKeys("notpwd");
            driver.FindElement(By.Name("Password")).Submit();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='validation-summary-errors text-danger']")));
            Assert.IsTrue(element.Displayed);
            
        }
        [Test]
        public void UserLoginUsername()
        {
            
            DoLoginUsername();
            Assert.AreEqual(driver.Url, HomePageOneWorkspace);
            
        }
        [Test]
        public void UserForgotPassword()
        {
            
            driver.Navigate().GoToUrl(URL);
            DoForgotPassword();
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='ContentPlaceHolder1_msgLabel']")));
            Assert.IsTrue(element.Displayed);
            
        }
    }
}
