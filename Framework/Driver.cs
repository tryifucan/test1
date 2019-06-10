using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public class Driver
    {
        public static IWebDriver driver { get; set; }

        public static void Initialize()
        {
            driver = new ChromeDriver(@"C:\Users\decha\source\repos\ExtentReportsTest\Framework\bin\Debug\netstandard2.0");
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
