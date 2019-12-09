using System;

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

            string[] numbersList = GetNumberList(userInput);

            if (numbersList.Length > 2) throw new Exception("More than 2 numbers were input");

            foreach (var item in numbersList)
            {
                int.TryParse(item, out int itemInteger);

                answer += itemInteger;
            }

            return answer;
        }

        private static string[] GetNumberList(string userInput)
        {
            string numberBlock = userInput;

            string[] delimiters = { ","};

            return numberBlock.Split(delimiters, StringSplitOptions.None);
        }
    }
}
