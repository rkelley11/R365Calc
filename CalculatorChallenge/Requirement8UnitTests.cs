using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorChallenge
{
    [TestClass]
    public class Requirement8UnitTests
    {
        [TestMethod]
        public void VerifySupportMultipleCustomDelimiterOfAnyLength()
        {
            int answer = Calculator.AddNumbers("//[*][!!][r9r]\n11r9r22*hh*33!!44");

            Assert.IsTrue(answer == 110);
        }
    }
}
