using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorChallenge
{
    [TestClass]
    public class RequirementOneUnitTests
    {
        [TestMethod]
        public void AcceptsSingleInteger()
        {
            int answer = Calculator.AddNumbers("20");

            Assert.IsTrue(answer == 20);
        }

        [TestMethod]
        public void AcceptsTwoPositiveIntegers()
        {
            int answer = Calculator.AddNumbers("1,5000");

            Assert.IsTrue(answer == 5001);
        }

        [TestMethod]
        public void AcceptsEmptyInput()
        {
            int answer = Calculator.AddNumbers("");

            Assert.IsTrue(answer == 0);
        }

        [TestMethod]
        public void ConvertsCharactersToZero()
        {
            int answer = Calculator.AddNumbers("5,tytyt");

            Assert.IsTrue(answer == 5);
        }
    }
}
