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
    public class Announcements: TestFixtureBase
    {
        

        [Test]
        public void AdminCanSendEmailPushAnnouncementToGroups()
        {
            
            //Open announcements
            driver.FindElement(By.Id("menuitem-nav_menu_announcements")).Click();
            driver.FindElement(By.XPath("//a[@href='javascript:void(0)']")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[@href='/announcement/create']")));
            
            //create new announcement
            driver.FindElement(By.XPath("//span[@href='/announcement/create']")).Click();
            driver.FindElement(By.Name("Title")).SendKeys("New Announcement");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ck-blurred ck ck-content ck-editor__editable ck-rounded-corners ck-editor__editable_inline']")));
            driver.FindElement((By.XPath("//div[@class='ck-blurred ck ck-content ck-editor__editable ck-rounded-corners ck-editor__editable_inline']"))).SendKeys("New Announcement body for the check");
            driver.FindElement(By.Id("ExpirationDate")).SendKeys(DateTime.Now.ToString("MM/dd/yyyy"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='chosen-container chosen-container-multi']")));
            driver.FindElement((By.XPath("//div[@class='chosen-container chosen-container-multi']"))).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='chosen-drop']")));
            driver.FindElement((By.XPath("//div[@class='chosen-drop']"))).Click();
            driver.FindElement((By.Id("TermsAndConditionsAccepted"))).Click();
            driver.FindElement((By.Id("btnPostAnnouncement"))).Click();

            //Assert announcement is posted
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='alert alert-success']")));
            Assert.IsTrue(element.Displayed);
          

        }
        
        public void AdminCanPostEmailPushTemplateAnnouncement()
        {
           

            

            //Open announcement templates
            driver.FindElement(By.Id("menuitem-nav_menu_announcements")).Click();
            driver.FindElement(By.XPath("//a[@href='javascript:void(0)']")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[@href='/announcement/template-landing']")));
            driver.FindElement(By.XPath("//span[@href='/announcement/template-landing']")).Click();

            //select announcement template
            driver.FindElement(By.Id("AnnouncementTemplate-35")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='/announcement/create?announcementTemplateID=35']")));
            driver.FindElement(By.XPath("//a[@href='/announcement/create?announcementTemplateID=35']")).Click();

            //Create the announcement
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("ExpirationDate")));
            driver.FindElement(By.Id("ExpirationDate")).SendKeys(DateTime.Now.ToString("MM / dd / yyyy"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='chosen-container chosen-container-multi']")));
            driver.FindElement((By.XPath("//div[@class='chosen-container chosen-container-multi']"))).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='chosen-drop']")));
            driver.FindElement((By.XPath("//div[@class='chosen-drop']"))).Click();
            driver.FindElement((By.Id("TermsAndConditionsAccepted"))).Click();
            driver.FindElement((By.Id("btnPostAnnouncement"))).Click();

            //Assert announcement is posted
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='alert alert-success']")));
            Assert.IsTrue(element.Displayed);
            
        }
        [Test]
        public void AdminCanPostEmailpushAnnouncementUnits()
        {
          

            driver.Navigate().GoToUrl(URL);

            //login to website
            DoLoginAdminOneWorkspace();

            //create new announcement
            driver.FindElement(By.XPath("//span[@href='/announcement/create']")).Click();
            driver.FindElement(By.Name("Title")).SendKeys("New Announcement");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ck-blurred ck ck-content ck-editor__editable ck-rounded-corners ck-editor__editable_inline']")));
            driver.FindElement((By.XPath("//div[@class='ck-blurred ck ck-content ck-editor__editable ck-rounded-corners ck-editor__editable_inline']"))).SendKeys("New Announcement body for the check");
            driver.FindElement(By.Id("ExpirationDate")).SendKeys(DateTime.Now.ToString("MM/dd/yyyy"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='chosen-container chosen-container-multi']")));
            driver.FindElement((By.XPath("//div[@class='chosen-container chosen-container-multi']"))).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='chosen-drop']")));
            driver.FindElement((By.XPath("//div[@class='chosen-drop']"))).Click();
            driver.FindElement((By.Id("TermsAndConditionsAccepted"))).Click();
            driver.FindElement((By.Id("btnPostAnnouncement"))).Click();
        }
        [Test]
        public void AdminCanPostLobbyDisplayAnnouncement()
        {
            

          
        }
        [Test]
        public void AdminCanViewListPage()
        {
            
            //Open announcements list page
            driver.FindElement(By.Id("menuitem-nav_menu_announcements")).Click();
            Assert.AreEqual(driver.Url, AnnouncementsListPage);
        }
       
        public void AdminCanEditAnnouncement()
        {
            

           

            //Open announcements list page
            driver.FindElement(By.Id("menuitem-nav_menu_announcements")).Click();
            
        }

        public void AdminCanViewAnnouncementDetails()
        {
            


            //Open announcements list page
            driver.FindElement(By.Id("menuitem-nav_menu_announcements")).Click();
            
        }

    }
}
