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
    public class SecurityAndConcierge : TestFixtureBase
    {
        [Test]
        //[TestCaseSource(typeof(TestFixtureBase),"BrowserToRunWith")]
        public void SecurityAndConciergePageLoads()
        { 
            driver.FindElement(By.Id("menuitem-nav_menu_security_and_concierge")).Click();
            var element = driver.FindElement(By.Id("linkIncidentReport"));
            Assert.IsTrue(element.Displayed);
        }


    }
}

