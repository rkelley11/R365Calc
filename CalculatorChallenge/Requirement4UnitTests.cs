using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorChallenge
{
    [TestClass]
    public class Requirement4UnitTests
    {
        [ExpectedException(typeof(Exception), "Invalid negative numbers were input: -20, -30, -75")]
        [TestMethod]
        public void VerifyNegativeNumbersThrowAnException()
        {
            int answer = Calculator.AddNumbers("10,-20,-30,40,50,60,-75,100,1000,1001");
        }
    }
}
