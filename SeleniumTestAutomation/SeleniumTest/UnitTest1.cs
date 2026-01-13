using NUnit.Framework;
using System;

namespace SeleniumTest
{
    public class Tests
    {
        /// <summary>
        //SetUp will run before each and every tests(ie once for test1 and again for test 2)
        ///Check output to understand
        /// </summary>
        [SetUp]
        public void Setup()
        {
            //Use "TestContext.Progress.WriteLine" : To log value of NUnit, instead of using "Console.WriteLine" 
            TestContext.Progress.WriteLine("Setting up tests...");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("This is test1");
        }
        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("This is test2");
        }
        [TearDown]
        public void TearDown()
        {
            TestContext.Progress.WriteLine("Tearing down tests...");
        }
    }
}
