using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CalculatorChallenge
{
    class Calculator
    {
        private static string[] NewLines = new string[] { Environment.NewLine, "\\n", "\n" };
        private static string NewLine;
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

            string[] delimiters = { ","};
            delimiters = CombineTwoArrays(delimiters, NewLines);

            if (userInput.Length > 2)
            {
                string firstTwoCharacters = userInput.Substring(0, 2);
                NewLine = DetermineNewLine(userInput);
                bool containsNewLine = !string.IsNullOrEmpty(NewLine);
                
                if (firstTwoCharacters.Equals("//") && containsNewLine)
                {
                    var userDefinedDelimiterList = ReturnDelimiters(userInput);
                    delimiters = CombineTwoArrays(delimiters, userDefinedDelimiterList);
                    int startOfNumbers = userInput.IndexOf(NewLine, StringComparison.CurrentCulture) + NewLine.Length;
                    numberBlock = userInput.Substring(startOfNumbers, userInput.Length - startOfNumbers);
                }
            }

            return numberBlock.Split(delimiters, StringSplitOptions.None);
        }

        private static string[] CombineTwoArrays(string[] array1, string[] array2)
        {
            var tempList = new List<string>();
            tempList.AddRange(array1);
            tempList.AddRange(array2);
            return tempList.ToArray();
        }

        private static string[] ReturnDelimiters(string numberString)
        {
            int endOfDelimiters = numberString.IndexOf(NewLine, StringComparison.CurrentCulture);
            string delimiterBlock = numberString.Substring(2, endOfDelimiters - 2);
            string regexSplitter = @"\[([^\]]*)\]";
            return Regex.Split(delimiterBlock, regexSplitter);
        }

        private static string DetermineNewLine(string input)
        {
            string newLine = null;
            foreach (string item in NewLines)
            {
                if (input.Contains(item))
                {
                    newLine = item;
                    break;
                }
            }

            return newLine;
        }
    }
}
