using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace Framework
{
    [TestFixture]
    public class Reporter
    {
       
        protected static AventStack.ExtentReports.ExtentReports _extent;
        protected static ExtentTest _test;

        ///For report directory creation and HTML report template creation
        ///For driver instantiation
        [OneTimeSetUp]
        public static void BeforeClass()
        {
            try
            {
                //To create report directory and add HTML report into it

                _extent = new AventStack.ExtentReports.ExtentReports();
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\netcoreapp2.1", "");
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
                var htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports\\Automation_Report.html");
                _extent.AddSystemInfo("Environment", "Staging");
                _extent.AddSystemInfo("User Name", "Daniel Echavaria");
                _extent.AttachReporter(htmlReporter);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        ///Getting the name of current running test to extent report
        [SetUp]
        public static void BeforeTest()
        {
            try
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        /// Finish the execution and logging the detials into HTML report
        [TearDown]
        public static void AfterTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        try
                        {
                            string screenShotFailedPath = Capture(Driver.driver, TestContext.CurrentContext.Test.Name);
                            _test.Log(logstatus, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotFailedPath));
                        }
                        catch
                        {
                            _test.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                        }                                                                    
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                    default:
                        logstatus = Status.Pass;
                        _test.Log(logstatus, "Test ended with " + logstatus);     
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        ///To flush extent report
        ///To quit driver instance
        [OneTimeTearDown]
        public static void AfterClass()
        {
            try
            {
                _extent.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        /// To capture the screenshot for extent report and return actual file path
        private static string Capture(IWebDriver driver, string screenShotName)
        {
            string localpath = "";
            try
            {
                Thread.Sleep(4000);
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\netcoreapp2.1", "");
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Defect_Screenshots\\");
                string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Defect_Screenshots\\" + screenShotName + ".png";
                localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return localpath;
        }
    }
}
