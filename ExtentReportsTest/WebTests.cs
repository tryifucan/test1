using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtentReportsTest
{
    public class WebTests : BaseWebClass
    {
        [Test]
        public void PassTest()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void FailTest()
        {
            Assert.IsTrue(false);
        }

    }
}
