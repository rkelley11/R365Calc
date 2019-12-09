using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorChallenge
{
    [TestClass]
    public class Requirement5UnitTests
    {
        [TestMethod]
        public void VerifyAnyNumberGreatetThan1000IsInvalid()
        {
            int answer = Calculator.AddNumbers("2,1001,6");

            Assert.IsTrue(answer == 8);
        }
    }
}
