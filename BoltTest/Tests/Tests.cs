using System;
using BoltTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BoltTest
{
    [TestFixture]
    public class Tests
    {
        public IWebDriver driver;
        
        string URL = "https://duckduckgo.com/";
        string uploadHistoryURL = "https://trade.stage.rapnet.com/#/uploadhistory";
        
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--kiosk");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait.Seconds.Equals(10);
            
        }

        [Test]
        public void Test1()
        {
            DuckSearch duck = new DuckSearch(driver);
            duck.OpenUrl(URL);
            duck.SearchElement();
            int num = duck.AutoComplete();
            Assert.AreEqual(num, 8);
            driver.Quit();
        }

        [Test]
        public void Test2()
        {
            DuckSearch duck = new DuckSearch(driver);
            duck.OpenUrl(URL);
            duck.SearchElement();
            duck.SearchButton();
            int num = duck.SearchResults();
            Assert.AreEqual(num , 10);
            int numresult = duck.SideBar();
            Assert.AreEqual(numresult , 1);
            driver.Quit();
        }
    }
}