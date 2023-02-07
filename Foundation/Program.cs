using System;
using ConsoleLibrary;

namespace Foundation
{
    class Program
    {
        public static bool IsNumeric(string strNumber)
        {
            double dblIsNumber;
            return double.TryParse(strNumber, out dblIsNumber);
        }
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hello World!");
            Console.WriteLine("What is your name? ");
            string strName = Console.ReadLine();
            Console.WriteLine("V1 - My name is " + strName + " you killed my Father, prepare to die!");
            Console.WriteLine("V2 - {0} {1}, I am your father!", strName, "Leia");
            Console.WriteLine($"V3 - Hello {IsNumeric("8")} ");
            */

            //DataTypes.Execute();
            // Converting.DoIt();
            //ValueReference.Execute();
            //Parameters.Engage();
            //Strings.DoItDangIt();
            //Arrays.BeginIt();

            /////////////////////////////////////////////////////////////////////////////////////
            //IO.Print("I am fine");
            //IO.GetConsoleInt("Enter an Integer between 0 and 10", 0, 10);
            //IO.GetConsoleBool("Enter either 'true' or 'false'");
            //IO.GetConsoleFloat("Enter a Float between 0 and 1", 0, 1);
            //IO.GetConsoleChar("Enter a Char");
            //IO.GetConsoleString("Enter a valid string, I don't really care what you write, but make it not a waste of data.");

            //string[] items = { "Test", "Here", "I don't like this" };
            //IO.ConsoleMenu(items);

            /////////////////////////////////////////////////////////////////////////////////////////
            ///Inheritance
            //Inheritance.Execute();

            ////////////////////////////////////////////////////////////////////////////////////////
            //Interfaces.Execute();
            /////////////////////////////////////////////////////////////////////////////////////////
            //Generics.Execute();
            //////////////////////////////////////////////////////////////////////////////////////
            ExtensionMethods.Execute();
        }
    }
}
