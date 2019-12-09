using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorChallenge
{
    [TestClass]
    public class Requirement7UnitTests
    {
        [TestMethod]
        public void VerifySupportOneCustomDelimiterOfAnyLength()
        {
            int answer = Calculator.AddNumbers("//[***]\n11***22***33");

            Assert.IsTrue(answer == 66);
        }

        [TestMethod]
        public void VerifyDoesNotSupportMultipleCustomDelimiters()
        {
            int answer = Calculator.AddNumbers("//[***][y7y]\n11***22y7y33");

            Assert.IsTrue(answer == 11);
        }
    }
}
