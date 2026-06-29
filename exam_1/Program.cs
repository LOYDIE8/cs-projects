using System;

namespace Exam
{
    class Exam1
    {
        public static void Main(String[] args)
        {
            bool Lp = true;
            while (Lp)
            {   
                System.Console.WriteLine("\nPlease enter a String!");
                String Input = (Console.ReadLine() ?? "").Trim().ToLower();
                if (String.IsNullOrWhiteSpace(Input))
                {
                    System.Console.WriteLine("Error! you entered an invalid String!");
                }
                else
                {
                    int vowels = 0;
                    foreach (char ch in Input)
                    {
                        if (ch is 'a' or 'e' or 'i' or 'o' or 'u')
                        {
                            vowels++;
                        }
                    }
                    System.Console.WriteLine($"There are {vowels} vowels in your String!");
                    System.Console.WriteLine($"you entered {Input.Count()} Characters!");
                }
                System.Console.WriteLine("Enter new one? y / n ");
                char choice = Console.ReadKey().KeyChar;
                if(choice is 'n')
                {
                    Lp = false;
                }
            }
        }
    }
}