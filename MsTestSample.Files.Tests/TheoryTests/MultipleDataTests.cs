using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MsTestSample.Files.Tests.TheoryTests
{
    [TestClass]
    public class MultipleDataTests
    {
        MathManager mathService;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mathService = new MathManager();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mathService = null;
        }

        [DataTestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(2, 2, 4)]
        [DataRow(3, 4, 7)]
        public void Sum_Returns_OfNumbers(int number1, int number2, int sumExpectation)
        {
            var result = this.mathService.Sum(number1, number2);

            Assert.AreEqual(sumExpectation, result);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetNumberSource), DynamicDataSourceType.Method)]
        public void Sum_Returns_DynamicData_OfNumbers(int a, int b, int expected)
        {
            var actual = this.mathService.Sum(a, b);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetNumberSource()
        {
            yield return new object[] { 1, 1, 2 };
            yield return new object[] { 2, 2, 4 };
            yield return new object[] { 3, 4, 7 };
        }
    }
}