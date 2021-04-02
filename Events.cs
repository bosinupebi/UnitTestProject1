using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace UnitTestProject1
{
    [TestFixture]
    public class Events:TestFixtureBase
    {
        [Test]
        public void EventsLandingLoads()
        {
            
            driver.FindElement(By.Id("menuitem-nav_menu_events")).Click();
            var element = driver.FindElement(By.Id("eventCalendar"));
            Assert.IsTrue(element.Displayed);

        }
    }
}
