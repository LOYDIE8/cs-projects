using System;

namespace Index
{
    class Calculator
    {
            static void UseCalc()
            {
                int num1, num2;
                Console.WriteLine("\nEnter first number: ");
                if(!int.TryParse(Console.ReadLine(), out num1))
                        {System.Console.WriteLine("ERROR you that is not a number!");
                        return;}
                Console.WriteLine("Choose action: +, -, *, / ");
                        char action = Console.ReadKey().KeyChar;
                Console.WriteLine("\nEnter second number: ");
                if(!int.TryParse(Console.ReadLine(), out num2))
                        {System.Console.WriteLine("ERROR you that is not a number!");
                        return;}  
                if(action == '/' || num2 == 0){System.Console.WriteLine("error you cannot devide with 0"); return;}  
                int result = action switch
                {
                    '+' => (num1 + num2),
                    '-' => (num1 - num2),
                    '*' => (num1 * num2),
                    '/' when num2 != 0 => (num1 / num2),
                };
                System.Console.WriteLine($"{num1} {action} {num2} = {result}");
                return;
            }
            static void Main(String[] args)
            {
                System.Console.WriteLine("wanna use calc? y/n");
                char calc = Console.ReadKey().KeyChar;
                while(calc == 'y')
            {
                UseCalc();
                System.Console.WriteLine("Continue using calc? y/n");
                calc = Console.ReadKey().KeyChar;
            }
            }
    }
}