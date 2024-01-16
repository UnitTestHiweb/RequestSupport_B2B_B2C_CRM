using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System.Threading;
using WebDriverManager.Helpers;
using OpenQA.Selenium.Interactions;

namespace RequestSupport.Connection
{
    public class Connection_Selenium
    {
        public IWebDriver driver { get; private set; }
        public WebDriverWait wait { get; private set; }
        public Actions action { get; private set; }

        // Manual WebDriver
        public Connection_Selenium()
        {
            string chromedriverpath = @"C:\Users\m.eftekhari\Desktop\RequestSupport\RequestSupport\Driver\chromedriver.exe";
            //string chromedriverpath = @"C:\Users\Mohammad\Desktop\RequestSupport\RequestSupport\Driver\chromedriver.exe";
            driver = new ChromeDriver(chromedriverpath);
            action = new Actions(driver);
            driver.Navigate().GoToUrl("https://p.hiweb.ir/login");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Manage().Window.Maximize();
        }

        //Get Dynamic Version Chrome WebDriver
        //public Connection_Selenium()
        //{
        //    // Install Version Chrome Driver = View > Other Windows > Package Manager Windows
        //    // Install-Package Selenium.WebDriver.ChromeDriver -Version 117.0.5938.9200
        //    // Install-Package Selenium.WebDriver.ChromeDriver -Version 118.0.5993.7000
        //    // Install-Package Selenium.WebDriver.ChromeDriver -Version 118.0.5993.70
        //    IWebDriver driver = new ChromeDriver();
        //    action = new Actions(driver);
        //    driver.Navigate().GoToUrl("https://p.hiweb.ir/login");
        //    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        //    driver.Manage().Window.Maximize();
        //}
    }
}

