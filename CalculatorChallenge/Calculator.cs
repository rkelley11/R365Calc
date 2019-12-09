using System;
using System.Collections.Generic;

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
                    answer += itemInteger;
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

            string[] delimiters = { ",", System.Environment.NewLine, "\\n" };

            return numberBlock.Split(delimiters, StringSplitOptions.None);
        }
    }
}
