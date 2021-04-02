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
    public class DiscussionForum : TestFixtureBase
    {
        [Test]
        public void AdminCanCreateANewForumNoModeration()
        {
           

            DoSetupPage();
       
            driver.FindElement(By.XPath("//a[@href='/setup/view-forum-and-classifieds-settings/']")).Click();
            driver.FindElement(By.XPath("//a[@href='#tab-1']")).Click();
            driver.FindElement(By.XPath("//a[@href='/setup/add-new-forum-classifieds?isAddClassifieds=False']")).Click();
            driver.FindElement(By.Id("ForumTitleModel")).SendKeys("General Discussion No Moderation");
            driver.FindElement(By.Id("Description")).SendKeys("Description for this forum");

            driver.FindElement(By.XPath("//input[@name='forumGroups']")).Click();
            driver.FindElement(By.Id("btnAddForum")).Click();
            Assert.AreEqual(driver.Url, ClassifiedForumsSetupURL);
            driver.Quit();
        }
        [Test]
        public void AdminCanCreateANewForumModeration()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 9));

            DoSetupPage();
            driver.FindElement(By.XPath("//a[@href='/setup/view-workspace-overview/12309']")).Click();
            driver.FindElement(By.XPath("//a[@href='/setup/view-forum-and-classifieds-settings/']")).Click();
            driver.FindElement(By.XPath("//a[@href='#tab-1']")).Click();
            driver.FindElement(By.XPath("//a[@href='/setup/add-new-forum-classifieds?isAddClassifieds=False']")).Click();
            driver.FindElement(By.Id("ForumTitleModel")).SendKeys("General Discussion Moderation");
            driver.FindElement(By.Id("Description")).SendKeys("Description for this forum");
            driver.FindElement(By.Id("ModeratorGroupIDModel")).Click();
            driver.FindElement(By.XPath("//option[@value='38697']")).Click();
            driver.FindElement(By.XPath("//input[@name='forumGroups']")).Click();
            driver.FindElement(By.Id("btnAddForum")).Click();
            Assert.AreEqual(driver.Url, ClassifiedForumsSetupURL);
            driver.Quit();
        }
        [Test]
        public void AdminCanCreateANewTopic()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 9));

            DoLoginAdminOneWorkspace();
            NavigateToDiscussionForum();
            driver.FindElement(By.XPath("//a[@href='/forum/new-thread/1164']")).Click();
            driver.FindElement(By.Id("NewForumTopic_Topic")).SendKeys("New Item for Your Consideration");
            driver.FindElement(By.XPath("//div[@class='ck-blurred ck ck-content ck-editor__editable ck-rounded-corners ck-editor__editable_inline']")).SendKeys("This topic is hereby open");
            driver.FindElement(By.Id("Save")).Click();
            Assert.AreEqual(driver.Url, DiscussionForumListPage);
        }
        
        [Test]
        public void AdminCanReplyTopic()
        {
            
            DoLoginAdminOneWorkspace();
            NavigateToDiscussionForum();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='/forum/view-topic/81087']")));
            driver.FindElement(By.XPath("//a[@href='/forum/view-topic/81087']")).Click();
            driver.FindElement(By.XPath("//a[@class='btnReply']")).Click();
            driver.FindElement(By.Id("Save")).Click();
        }
        [Test]
        public void ResidentCanReplyTopic()
        {
            
            DoLoginResident();
            NavigateToDiscussionForum();
        }
        [Test]
        public void UserCanQuoteReplyInATopic()
        {

        }
        [Test]
        public void AdminCanFollowOrUnfollowATopic()
        {

        }
        [Test]
        public void AdminCanFollowOrUnfollowAThread()
        {

        }
        [Test]
        public void ResidentCanFollowOrUnfollowATopic()
        {

        }
        [Test]
        public void ResidentCanFollowOrUnfollowAThread()
        {

        }
        [Test]
        public void AdminCanDeleteATopicReply()
        {

        }
    }
}
