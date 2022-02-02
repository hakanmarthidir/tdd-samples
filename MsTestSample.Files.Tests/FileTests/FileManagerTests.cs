using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsTestSample.Files.Tests.TestSetup;
using System;

namespace MsTestSample.Files.Tests.FileTests
{
    [TestClass]
    public class FileManagerTests : TestBase
    {        
        private FileManager _fileManager;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            testContext.WriteLine("FileManagerTests initializing...");            
        }

        [ClassCleanup]
        public static void ClassCleanup()
        { }

        [TestInitialize]
        public void TestInitialize()
        {         
            _fileManager = new FileManager();
            WriteDescription(this.GetType());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _fileManager = null;
        }

        [TestMethod]
        [Owner("HH")]
        [Priority(1)]
        [TestCategory("BasedValueCheck")]
        [Description("check for existing file path")]
        public void ShouldBeTrueIfFileExists()
        {            
            TestContext.WriteLine("File is checking ...");
            bool result = _fileManager.FileExists(@"..\..\..\TestSetup\Files.runsettings");

            Assert.IsTrue(result, "File is not exist...");
        }

        [TestMethod]
        [Owner("HH")]
        [Priority(1)]
        [TestCategory("BasedValueCheck")]
        public void ShouldBeFalseIfFileNotExists()
        {           
            bool result = _fileManager.FileExists(GetParameterFromSetttingsFile("GoodFileName"));

            Assert.IsFalse(result);
        }

        [TestMethod]
        [Owner("MH")]
        [Priority(2)]
        [TestCategory("BasedException")]
        [Timeout(50)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionIfFileNameIsEmpty()
        {            
            bool result = _fileManager.FileExists("");
        }

        [Owner("HH")]
        [TestMethod]
        [Priority(3)]
        [TestCategory("BasedException")]
        [Timeout(50)]
        //[Ignore]
        public void ShouldThrowExceptionIfFileNameIsNull()
        {           
            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                bool result = _fileManager.FileExists(null);
            });  
        }


    }
}