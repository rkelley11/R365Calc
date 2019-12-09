using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorChallenge
{
    [TestClass]
    public class Requirement6UnitTests
    {
        [TestMethod]
        public void VerifySupportOneSingleCharacterCustomDelimiter1()
        {
            int answer = Calculator.AddNumbers("//#\n2#5");

            Assert.IsTrue(answer == 7);
        }

        [TestMethod]
        public void VerifySupportOneSingleCharacterCustomDelimiter2()
        {
            int answer = Calculator.AddNumbers("//,\n2,ff,100");

            Assert.IsTrue(answer == 102);
        }
    }
}
