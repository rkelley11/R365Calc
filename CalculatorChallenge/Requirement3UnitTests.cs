﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorChallenge
{
    [TestClass]
    public class Requirement3UnitTests
    {
        [TestMethod]
        public void AcceptsNewLineDelimiter()
        {
            int answer = Calculator.AddNumbers("1\n2,3");

            Assert.IsTrue(answer == 6);
        }
    }
}
