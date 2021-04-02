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
    public class Tasks: TestFixtureBase
    {
        [Test]
        public void TasksLandingLoads()
        {
            driver.FindElement(By.Id("menuitem-nav_menu_tasks")).Click();
            var element = driver.FindElement(By.XPath("//a[@href='/task/new-task/']"));
            Assert.IsTrue(element.Displayed);
        }

    }
}
