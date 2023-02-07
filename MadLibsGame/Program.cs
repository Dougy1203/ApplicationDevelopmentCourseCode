using System;
using System.Collections.Generic;

namespace MadLibsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> madLib = PromptUser();
            Console.WriteLine(madLib["noun"]);

        }
        public static Dictionary<string, string> PromptUser()
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

            Dictionary<string, string> madLibs = new Dictionary<string, string>();
            madLibs.Add("noun", noun);
            madLibs.Add("verb", verb);
            madLibs.Add("adjective", adjective);
            madLibs.Add("adverb", adverb);
            madLibs.Add("preposition", preposition);
            madLibs.Add("noun2", noun2);

            return madLibs;
        }
    }
}
