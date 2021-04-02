using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTestProject1
{
    public class TestFixtureBase
    {
        protected String URL = "https://condocontrolcentral.com:500/login/";
        protected String HomePageOneWorkspace = "https://condocontrolcentral.com:500/my/my-home";
        protected String MultipleWorkspaceListPage = "https://condocontrolcentral.com:500/login/multiple-workspace?NextPage=";
        protected String AnnouncementsListPage = "https://condocontrolcentral.com:500/announcement/show-list/";
        protected String ClassifiedForumsSetupURL = "https://condocontrolcentral.com:500/setup/view-forum-and-classifieds-settings";
        protected String ClassifiedAdsForumListPage = "https://ccc-prod2.condocontrolcentral.com:500/forum/view-forum/1157?mode=classifieds";
        protected String DiscussionForumListPage = "https://condocontrolcentral.com:500/forum/view-forum/1164";
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [SetUp]
        public void Open()
        {
            
            driver = new ChromeDriver();
           
            driver.Manage().Window.Maximize();
           
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            driver.Url = URL;
            driver.FindElement(By.Name("Username")).SendKeys("test@manager.com");
            driver.FindElement(By.Name("Password")).SendKeys("123456");
            driver.FindElement(By.Name("Password")).Submit();
        }

        [TearDown]
        public void Close()
        {

            driver.Quit();

        }

        protected void DoLoginAdminOneWorkspace()
        {

            driver.FindElement(By.Name("Username")).SendKeys("test@manager.com");
            driver.FindElement(By.Name("Password")).SendKeys("123456");
            driver.FindElement(By.Name("Password")).Submit();
        }
        protected void DoLoginResident()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Name("Username")).SendKeys("ownerone@mail.com");
            driver.FindElement(By.Name("Password")).SendKeys("123456");
            driver.FindElement(By.Name("Password")).Submit();
            
        }
        protected void DoLoginAdminMultipleWorkspace()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Name("Username")).SendKeys("1@pm.com");
            driver.FindElement(By.Name("Password")).SendKeys("pm987987");
            driver.FindElement(By.Name("Password")).Submit();
        }
        protected void DoLoginPortfolio()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Name("Username")).SendKeys("");
            driver.FindElement(By.Name("Password")).SendKeys("");
            driver.FindElement(By.Name("Password")).Submit();
        }
        protected void DoLoginUsername()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Name("Username")).SendKeys("username");
            driver.FindElement(By.Name("Password")).SendKeys("123456");
            driver.FindElement(By.Name("Password")).Submit();
        }
        protected void DoForgotPassword()
        {
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.XPath("//a[@href='/request-password-reset.aspx']")).Click();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("ContentPlaceHolder1_emailAddressControl")));
            driver.FindElement(By.Id("ContentPlaceHolder1_emailAddressControl")).SendKeys("bo@condocontrolcentral.com");
            driver.FindElement(By.Id("ContentPlaceHolder1_btnSubmit"));
        }
        protected void DoUSDCard()
        {
            
        }
        protected void DoCADCard()
        {
            
        }
        protected void DoMXNCard()
        {

        }
        protected void NavigateToClassifiedAds()
        {
            driver.FindElement(By.Id("menuitem-nav_menu_classified")).Click();
            
            driver.FindElement(By.XPath("//a[@href='/forum/view-forum/1157?mode=classifieds']")).Click();
        }
        protected void NavigateToDiscussionForum()
        {
            driver.FindElement(By.Id("menuitem-nav_menu_discussion_forum")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='/forum/view-forum/1164']")));
            driver.FindElement(By.XPath("//a[@href='/forum/view-forum/1164']")).Click();
            
        }
        protected void NavigateToEvents()
        {
            driver.FindElement(By.Id("menuitem-nav_menu_events")).Click();
           
            driver.FindElement(By.XPath("//a[@href='/forum/view-forum/1164']")).Click();

        }
        protected void DoSetupPage()
        {
            driver.FindElement(By.Id("avatarMenu")).Click();
            driver.FindElement(By.XPath("//a[@href='/setup/view-workspace-overview/12309']")).Click();
        }

    }
}
