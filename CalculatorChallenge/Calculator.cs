﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CalculatorChallenge
{
    class Calculator
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a set of numbers to be added:");

            string numbersInput = Console.ReadLine();

            int answer = AddNumbers(numbersInput);

            Console.WriteLine("The answer is " + answer.ToString());
        }

        public static int AddNumbers(string userInput)
        {
            int answer = 0;

            List<string> negativeNumberList = new List<string>();

            string[] numbersList = GetNumberList(userInput);

            foreach (var item in numbersList)
            {
                int.TryParse(item, out int itemInteger);

                if (itemInteger < 0)
                {
                    negativeNumberList.Add(itemInteger.ToString());
                }
                else
                {
                    if (itemInteger <= 1000)
                    {
                        answer += itemInteger;
                    }
                }
            }

            if (negativeNumberList.Count > 0)
            {
                string invalidNumbers = string.Join(", ", negativeNumberList.ToArray());

                throw new Exception("Invalid negative numbers were input: " + invalidNumbers);
            }

            return answer;
        }

        private static string[] GetNumberList(string userInput)
        {
            string numberBlock = userInput;

            string[] delimiters = { ",", Environment.NewLine, "\\n" };

            if (userInput.Length > 2)
            {
                string firstTwoCharacters = userInput.Substring(0, 2);
                bool containsNewLine = userInput.Contains("\\n") ||
                    userInput.Contains(Environment.NewLine);

                if (firstTwoCharacters.Equals("//") && containsNewLine)
                {
                    var userDefinedDelimiterList = ReturnDelimiters(userInput);

                    var tempList = new List<string>();
                    tempList.AddRange(delimiters);
                    tempList.AddRange(userDefinedDelimiterList);
                    delimiters = tempList.ToArray();

                    string newLine = userInput.Contains("\\n") ? "\\n" : Environment.NewLine;

                    int startOfNumbers = userInput.IndexOf(newLine, StringComparison.CurrentCulture) + newLine.Length;

                    numberBlock = userInput.Substring(startOfNumbers, userInput.Length - startOfNumbers);
                }
            }

            return numberBlock.Split(delimiters, StringSplitOptions.None);
        }

        private static string[] ReturnDelimiters(string numberString)
        {
            string newLine = numberString.Contains("\\n") ? "\\n" : Environment.NewLine;

            int endOfDelimiters = numberString.IndexOf(newLine, StringComparison.CurrentCulture);

            string delimiterBlock = numberString.Substring(2, endOfDelimiters - 2);

            string regexSplitter = @"\[([^\]]*)\]";

            return Regex.Split(delimiterBlock, regexSplitter);
        }
    }
}
