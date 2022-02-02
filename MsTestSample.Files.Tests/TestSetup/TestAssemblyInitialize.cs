using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestSample.Files.Tests.TestSetup
{
    [TestClass]
    public class TestAssemblyInitialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            testContext.WriteLine("Assembly initializing ...");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
           //TODO for cleaning up
        }
    }
}