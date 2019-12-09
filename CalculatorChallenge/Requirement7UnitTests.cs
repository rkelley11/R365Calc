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
    }
}
