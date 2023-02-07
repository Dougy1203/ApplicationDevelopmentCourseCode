using System;

namespace MadLibGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            PromptUser();
        }

            public static string[] PromptUser()
        {
            string noun;
            string verb;
            string adjective;
            string adverb;
            string preposition;
            string noun2;

            Console.WriteLine("Welcome to our MadLib Generator");
            noun = ConsoleLibrary.IO.GetConsoleString("Enter a Noun: ");
            verb = ConsoleLibrary.IO.GetConsoleString("Enter a Verb: ");
            adjective = ConsoleLibrary.IO.GetConsoleString("Enter an Adjective: ");
            adverb = ConsoleLibrary.IO.GetConsoleString("Enter an Adverb: ");
            preposition = ConsoleLibrary.IO.GetConsoleString("Enter a Preposition: ");
            noun2 = ConsoleLibrary.IO.GetConsoleString("Enter another Noun: ");

            string[] madLibs = { noun, verb, adjective, adverb, preposition, noun2 };

            return madLibs;
        }
    }
}
