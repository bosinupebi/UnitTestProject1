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
    public class AmenityBooking:TestFixtureBase
    {
        [Test]
        public void AmenityBookingLoads()
        {
            driver.FindElement(By.Id("menuitem-nav_menu_amenity_bookings")).Click();
            var element = driver.FindElement(By.Id("bookingCalendar"));
            Assert.IsTrue(element.Displayed);
        }

        
    }
}
