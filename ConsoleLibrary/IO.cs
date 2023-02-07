using System;

namespace ConsoleLibrary
{
    public static class IO
    {
        public static void Print(string stringToPrint) 
        {
            Console.WriteLine(stringToPrint);
        }

        public static int GetConsoleInt(string message, int min, int max)
        {
            bool success = false;
            int typedValue;
            do
            {
                Console.WriteLine(message);
                success = int.TryParse(Console.ReadLine(), out typedValue);
                
                success = success && typedValue >= min && typedValue <= max;

                if (!success)
                {
                    Console.WriteLine("You Entered an Invalid Value, Must be between {0} and {1} and be a Valid Integer.", min, max);
                }
            } while (!success);
            Print($"You entered {typedValue}");
            return typedValue;
        }

        public static bool GetConsoleBool(string message)
        {
            bool check = false;
            bool checker = false;
            do
            {
                Console.WriteLine(message);
                if (Console.ReadLine().Equals("true"))
                {
                    check = true;
                    checker = true;
                }
                else if (Console.ReadLine().Equals("false"))
                {
                    check = false;
                    checker = true;
                }
            } while (!checker);
            Print($"You entered {check}");
            return check;
        }

        public static float GetConsoleFloat(string message, int min, int max)
        {
            bool check = false;
            float typedValue;
            do
            {
                Console.WriteLine(message);
                check = float.TryParse(Console.ReadLine(), out typedValue);
                check = check && typedValue > min && typedValue < max;

                if (!check)
                {
                    Console.WriteLine("You Entered an Invalid Value, Must be between {0} and {1} and be a Valid Float.", min, max);
                }
            } while (!check);
            Print($"You entered {typedValue}");
            return typedValue;
        }

        public static char GetConsoleChar(string message)
        {
            bool check = false;
            char chars = ' ';
            do
            {
                Console.WriteLine(message);
                check = char.TryParse(Console.ReadLine(), out chars);
                if(!check)
                {
                    Console.WriteLine("It's not hard, you enter a single character. Like click one button and then submit. Easy.");
                }

            } while (!check);
            Print($"You entered {chars}");
            return chars;
        }

        public static string GetConsoleString(string message)
        {
            bool check = false;
            string strings;
            do
            {
                Console.WriteLine(message);
                strings = Console.ReadLine();
                if (strings.Length == 0)
                {
                    Console.WriteLine("You seriously just have to type anything. How dumb are you?");
                }
                else
                {
                    check = true;
                }
            } while (!check);
            Print($"You entered {strings}");
            return strings;
        }

        public static int ConsoleMenu(string[] items) {
            bool success = false;
            int typedValue;
            int menuNumber = 1;
            do
            {
                Console.WriteLine("Enter a Numer from the Menu Below to Select that item.");
                foreach(string item in items)
                {
                    Console.WriteLine($"{menuNumber}- {item}");
                    menuNumber++;
                }
                success = int.TryParse(Console.ReadLine(), out typedValue);

                success = success && typedValue >= 1 && typedValue <= items.Length;

                if (!success)
                {
                    Console.WriteLine("You Entered an Invalid Menu Item Value, Must be between {0} and {1} and be a Valid Integer.", 1, items.Length);
                    menuNumber = 1;
                }
            } while (!success);
            Print($"You entered {typedValue}, {items[typedValue-1]}");
            return typedValue;
        }
    }
}
