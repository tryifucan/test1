using Framework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtentReportsTest
{
    public class BaseWebClass
    {

        [SetUp]
        public void SetUp()
        {
            Reporter.BeforeClass();
            Driver.Initialize();
            Reporter.BeforeTest();
        }

        [TearDown]
        public void TearDown()
        {
            Reporter.AfterTest();
            Reporter.AfterClass();
            Driver.driver.Quit();
        }
    }
}
