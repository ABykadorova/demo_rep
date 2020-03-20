using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    public class Tests
    {

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]
        public void Test1()
        {
            IWebElement newsButton = driver.FindElement(By.XPath("//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
            newsButton.Click();
            
            IWebElement topNews = driver.FindElement(By.XPath("//div[@data-entityid='container-top-stories#1']/div[1]//h3"));
            string actualTopNews = topNews.Text;
            string expectedTopNews = "China coronavirus deaths and cases spike"; 
            Assert.AreEqual(actualTopNews, expectedTopNews);

            driver.Quit();
        }

        [Test]
        public void Test2()
        {
            IWebElement newsButton = driver.FindElement(By.XPath("//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
            newsButton.Click();

            
            IWebElement firstArticle = driver.FindElement(By.XPath("//div[@data-entityid='container-top-stories#2']/div[2]//h3"));
            IWebElement secondArticle = driver.FindElement(By.XPath("//div[@data-entityid='container-top-stories#3']/div[2]//h3"));
            IWebElement thirdArticle = driver.FindElement(By.XPath("//div[@data-entityid='container-top-stories#4']/div[2]//h3"));
            IWebElement fourthArticle = driver.FindElement(By.XPath("//div[@data-entityid='container-top-stories#5']//h3"));
            IWebElement fifthArticle = driver.FindElement(By.XPath("//div[@data-entityid='container-top-stories#6']//h3"));

            List<String> articles = new List<String>();
            articles.Add(firstArticle.Text);
            articles.Add(secondArticle.Text);
            articles.Add(thirdArticle.Text);
            articles.Add(fourthArticle.Text);
            articles.Add(fifthArticle.Text);

            List<String> expected = new List<String>();
            expected.Add("UK chancellor quits amid Cabinet reshuffle drama");
            expected.Add("Macron vows to save Mont Blanc from overcrowding");
            expected.Add("Top Trump aide Hope Hicks returning to White House");
            expected.Add("Prankster hangs Putin portrait in Moscow lift");
            expected.Add("Mexicans post 'beautiful images' for murdered woman");

            Assert.AreEqual(articles, expected);

            driver.Quit();
        }

        [Test]
        public void Test3()
        {
           
            IWebElement newsButton = driver.FindElement(By.XPath("//div[@id='orb-nav-links']//a[contains(text(), 'News')]"));
            newsButton.Click();

            IWebElement popularWord = driver.FindElement(By.XPath("//div[@data-entityid='container-top-stories#1']/div[1]/ul/li[2]/a/span"));
            string toFind = popularWord.Text;

            IWebElement searchButton = driver.FindElement(By.XPath("//input[@id='orb-search-q']"));
            searchButton.SendKeys(toFind);

            IWebElement findButton = driver.FindElement(By.XPath("//button[@id='orb-search-button']"));
            findButton.Click();

            IWebElement findElement= driver.FindElement(By.XPath("//section[@id='search-content']/ol[1]/li[1]/article/div/h1/a"));
            string toCompare = findElement.Text;

            Assert.AreEqual(toFind, toCompare);

            driver.Quit();
        }
    }
}