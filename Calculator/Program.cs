using System.Text.RegularExpressions;
using CalculatorLibrary;

namespace CalculatorProgram;
class Program
{
    static void Main(string[] args)
    {
        bool endapp = false;

        Console.WriteLine("Calculator App in C#");

        // Program.cs
        Calculator calculator = new Calculator();

        while (!endapp)
        {
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            Console.WriteLine("Type a number, and press enter:");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }

            Console.Write("Type another number, and then press Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
           
            while(!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }
            
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\t a - Add");
            Console.WriteLine("\t s - Subtract");
            Console.WriteLine("\t m - Multiply");
            Console.WriteLine("\t d - Divide");
            Console.WriteLine("Your option? ");


            string? op = Console.ReadLine();

            if (op == null || ! Regex.IsMatch(op, "[a|s|m|d]"))
            {
                Console.WriteLine("Error: unrecognized input.");
            }
            else
            { 
                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);

                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");

                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Oh no! an exception ocurred trying to calculate.\n - Details: " + ex.Message);
                }
            }
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endapp = true;

            Console.WriteLine("\n");

        }
        calculator.Finish();
        return;
    }
}