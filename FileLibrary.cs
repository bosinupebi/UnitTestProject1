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
    public class FileLibrary: TestFixtureBase
    {
        [Test]
        public void FileLibraryLoads()
        {
          driver.FindElement(By.Id("menuitem-nav_menu_library")).Click();
          var element = driver.FindElement(By.XPath("//div[@class='dashboard']"));
          Assert.IsTrue(element.Displayed);
        }
        [Test]
        public void AdminCanViewFolder()
        {

        }
        [Test]
        public void AdminCanDeleteFolder()
        {

        }
        [Test]
        public void AdminCanRenameFolder()
        {

        }
        [Test]
        public void AdminCanMoveFolder()
        {

        }
        [Test]
        public void AdminCanUpdateFolderPermissions()
        {

        }
        [Test]
        public void AdminCanReviseFileDetails()
        {

        }
        [Test]
        public void FileIdPermission()
        {

        }
        [Test]
        public void FolderIdPermission()
        {

        }
        [Test]
        public void RecentlyUpdatedWidget()
        {

        }

    }
}
