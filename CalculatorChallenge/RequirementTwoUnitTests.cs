using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorChallenge
{
    [TestClass]
    public class RequirementTwoUnitTests
    {
        [TestMethod]
        public void AcceptsManyIntegers()
        {
            int answer = Calculator.AddNumbers("1,2,3,4,5,6,7,8,9,10,11,12");

            Assert.IsTrue(answer == 78);
        }
    }
}
