using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BoltTest.Pages
{
    public class DuckSearch
    {
        private IWebDriver driver;
        
        public List<IWebElement> content_data = new List<IWebElement>();  

        public DuckSearch(IWebDriver driver)
        {
            this.driver = driver;
        }


        By Search = By.Id("search_form_input_homepage");
        By Auto = By.XPath("//*[@id='search_form_homepage']/div[2]/div[1]");
        By Searchbutton = By.Id("search_button_homepage");
        By LinksResults = By.Id("links");
        By CssResult = By.CssSelector("div[class='result results_links_deep highlight_d result--url-above-snippet']");
        By SideBarResult = By.XPath("//*[@id='links_wrapper']/div[2]");
        By SideResult = By.CssSelector("div[class='sidebar-modules js-sidebar-modules']");

        public void OpenUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        
        public void SearchElement()
        {
            driver.FindElement(Search).SendKeys("watermelons");
        }

        public void SearchButton()
        {
            driver.FindElement(Searchbutton).Click();
        }

        public int AutoComplete()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            content_data = driver.FindElement(Auto).FindElements(By.TagName("div")).ToList();
            int num = content_data.Count;
            string name = content_data[1].Text;
            return num;
        }

        public int SearchResults()
        {
            content_data = driver.FindElement(LinksResults).FindElements(CssResult).ToList();
            int num = content_data.Count;
            return num;
        }

        public int SideBar()
        {
            content_data = driver.FindElement(SideBarResult).FindElements(SideResult).ToList();
            int num = content_data.Count;
            return num;
        }
    }
}