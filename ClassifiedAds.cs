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
    public class ClassifiedAds: TestFixtureBase
    {
        [Test]
        public void AdminCanCreateANewForumNoModeration()
        {
           

            //DoSetupPage(driver);
            driver.FindElement(By.XPath("//a[@href='/setup/view-workspace-overview/12309']")).Click();
            driver.FindElement(By.XPath("//a[@href='/setup/view-forum-and-classifieds-settings/']")).Click();
            driver.FindElement(By.XPath("//a[@href='#tab-2']")).Click();
            driver.FindElement(By.XPath("//a[@href='/setup/add-new-forum-classifieds?isAddClassifieds=True']")).Click();
            driver.FindElement(By.Id("ForumTitleModel")).SendKeys("Locker Rentals");
            driver.FindElement(By.Id("Description")).SendKeys("Description for this forum");
            
            driver.FindElement(By.XPath("//input[@name='forumGroups']")).Click();
            driver.FindElement(By.Id("btnAddForum")).Click();
            Assert.AreEqual(driver.Url, ClassifiedForumsSetupURL);
            driver.Quit();
        }
        [Test]
        public void AdminCanCreateANewForumModeration()
        {
           

            DoSetupPage();
           
            driver.FindElement(By.XPath("//a[@href='/setup/view-forum-and-classifieds-settings/']")).Click();
            driver.FindElement(By.XPath("//a[@href='#tab-2']")).Click();
            driver.FindElement(By.XPath("//a[@href='/setup/add-new-forum-classifieds?isAddClassifieds=True']")).Click();
            driver.FindElement(By.Id("ForumTitleModel")).SendKeys("Locker Rentals");
            driver.FindElement(By.Id("Description")).SendKeys("Description for this forum");
            driver.FindElement(By.Id("ModeratorGroupIDModel")).Click();
            driver.FindElement(By.XPath("//option[@value='38697']")).Click();
            driver.FindElement(By.XPath("//input[@name='forumGroups']")).Click();
            driver.FindElement(By.Id("btnAddForum")).Click();
            Assert.AreEqual(driver.Url, ClassifiedForumsSetupURL);
            driver.Quit();
        }
        [Test]
        public void AdminCanPostAd()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            
           
           

            //Open classified ads
            NavigateToClassifiedAds();

            driver.FindElement(By.XPath("//a[@href='/forum/new-thread/1157?mode=classifieds']")).Click();
            driver.FindElement(By.Id("NewForumTopic_Topic")).SendKeys("New Item for Sale");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ck-blurred ck ck-content ck-editor__editable ck-rounded-corners ck-editor__editable_inline']")));
            driver.FindElement((By.XPath("//div[@class='ck-blurred ck ck-content ck-editor__editable ck-rounded-corners ck-editor__editable_inline']"))).SendKeys("selling a car");
            driver.FindElement(By.Name("NewForumTopic.Price")).SendKeys("100");
            driver.FindElement(By.Id("btnCreate")).Click();

            //Assert classified ad is posted
            Assert.AreEqual(driver.Url, ClassifiedAdsForumListPage);
            driver.Quit();
        }
        
        /*public void ResidentCanPostAd()
        {
            var driver = new ChromeDriver();//new chrome instance in variable driver

            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5)); // web driver wait time frame, moves on once found, keeps checking for 5s if not

            //go to test website and login
            
            DoLoginResident(driver);
       
            NavigateToClassifiedAds(driver, wait);

            driver.FindElement(By.XPath("//a[@href='/forum/new-thread/1157?mode=classifieds']")).Click();
            driver.FindElement(By.Id("NewForumTopic_Topic")).SendKeys("New Item for Sale");
            driver.FindElement((By.XPath("//div[@class='ck-blurred ck ck-content ck-editor__editable ck-rounded-corners ck-editor__editable_inline']"))).SendKeys("selling a car");
            driver.FindElement(By.Name("NewForumTopic.Price")).SendKeys("100");
            driver.FindElement(By.Id("btnCreate")).Click();

            //Assert classified ad is posted
            Assert.AreEqual(driver.Url, "https://condocontrolcentral.com:500/forum/view-forum/1157?mode=classifieds");
            driver.Quit(); 
           
        }
        */

        [Test]
        public void UserCanFollowAForum()
        {
     
            //Open classified ads
            NavigateToClassifiedAds();
            driver.FindElement(By.Id("updateFollower")).Click();
            var element = driver.FindElement(By.Id("updateFollower"));
            Assert.IsTrue(element.Displayed);


        }

        [Test]
        public void UserCanUnfollowAForum()
        {

            NavigateToClassifiedAds();
            driver.FindElement(By.Id("updateFollower")).Click();
            var element = driver.FindElement(By.Id("updateFollower"));
            Assert.IsTrue(element.Displayed);
        }
        [Test]
        public void UserCanRespondToAClassfiedAd()
        {

            NavigateToClassifiedAds();
           
            driver.FindElement(By.XPath("//a[@href='/forum/view-topic/71082?mode=classifieds']")).Click();

            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("Contact the seller")));
            Assert.IsTrue(element.Enabled);
            driver.Quit();
        }

        [Test]
        public void UserCanDeleteAClassfiedAd()
        {
            

            NavigateToClassifiedAds();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='/forum/view-topic/71081?mode=classifieds']")));
            driver.FindElement(By.XPath("//a[@href='/forum/view-topic/71081?mode=classifieds']")).Click();
            driver.FindElement(By.XPath("//a[@class='btnDeleteMessage']")).Click();


            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(.,'Delete')]")));
            Assert.IsTrue(element.Enabled);
        }
        [Test]
        public void AdminCanMarkPostAsExpired()
        {
           

            //Open classified ads

            NavigateToClassifiedAds();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='/forum/view-topic/71081?mode=classifieds']")));
            driver.FindElement(By.XPath("//a[@href='/forum/view-topic/71081?mode=classifieds']")).Click();
            driver.FindElement(By.XPath("//a[@class='btnExpireMessage']")).Click();
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(.,'Yes')]")));
            Assert.IsTrue(element.Enabled);
            driver.Quit();


        }
        [Test]
        public void AdminCanHideAdOnTvDisplay()
        {
          

            //Open classified ads

            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='/forum/view-topic/71055?mode=classifieds']")));
            driver.FindElement(By.XPath("//a[@href='/forum/view-topic/71055?mode=classifieds']")).Click();
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='btnHideTVDisplay']")));
            driver.FindElement(By.XPath("//a[@class='btnHideTVDisplay']")).Click();
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(.,'Yes')]")));
            Assert.IsTrue(element.Enabled);
            driver.Quit();
        }



    }
}
