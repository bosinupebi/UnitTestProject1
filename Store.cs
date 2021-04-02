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
    public class Store:TestFixtureBase
    {
        [Test]
        public void StoreLandingLoads()
        {
            driver.FindElement(By.Id("menuitem-nav_menu_store")).Click();
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='#tab-2']")));
            Assert.IsTrue(element.Enabled);
        }
        [Test]
        public void ResidentCanPlaceAnOrder()
        {

        }
        [Test]
        public void AdminCanPlaceAnOrder()
        {

        }
        [Test]
        public void InternationalCardTransaction()
        {

        }
        [Test]
        public void AdminCanCancelAnOrder()
        {

        }
        [Test]
        public void AdminCanViewAllOrders()
        {

        }
        [Test]
        public void ResidentCanViewMyOrders()
        {

        }
        [Test]
        public void AdminCanFilterStoreListPage()
        {

        }
        [Test]
        public void ResidentCanFilterStoreListPage()
        {

        }
        [Test]
        public void CreatePackageForPickup()
        {

        }
    }
}
