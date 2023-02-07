using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterMindLibrary
{
    public static class MMLib
    {

        /// <summary>
        /// Creates an answer for this game that the user has to guess.
        /// </summary>
        /// <param name="maxPieces">Number of pegs in this game</param>
        /// <returns>Array with the chosen number of pegs mixed up.</returns>
        public static List<int> GenerateAnswer(int maxPegs)
        {
            List<int> answer = new List<int>();

            for (int pieces = 0; pieces < maxPegs; pieces++)
            {
                answer.Add(pieces);
            }

            //Randomly sort them 
            Random random = new Random();
            return answer.OrderBy(item => random.Next()).ToList();
        }

        /// <summary>
        /// Displays the attempts the user has made up to this point.
        /// </summary>
        /// <param name="allAttempts">List of all the attempts the user has made</param>
        /// <param name="pegList">List of peg color options</param>
        /// <param name="pegSymbol">Symbol to show in the middle of the peg</param>
        public static void ShowAttempts(List<Attempt> allAttempts, List<Peg> pegList, string pegSymbol)
        {
            foreach (Attempt attempt in allAttempts)
            {
                for (int pegChoice = 0; pegChoice < attempt.AttemptList.Count; pegChoice++)
                {
                    Console.ResetColor();
                    Console.Write(" ");
                    Console.ForegroundColor = pegList[attempt.AttemptList[pegChoice]].TextColor;
                    Console.BackgroundColor = pegList[attempt.AttemptList[pegChoice]].PegColor;
                    Console.Write(" {0} ", pegSymbol);
                    Console.ResetColor();
                    Console.Write(" ");
                }
                Console.Write("        {0} Correct", attempt.CorrectAnswerCount);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Displays the answer to the game to the console.
        /// </summary>
        /// <param name="answer">List of indexes composing the answer</param>
        /// <param name="pegList">List of peg color options</param>
        /// <param name="pegSymbol">Symbol to show in the middle of the peg</param>
        public static void ShowAnswer(List<int> answer, List<Peg> pegList, string pegSymbol)
        {
            for (int a = 0; a < answer.Count; a++)
            {
                Console.ResetColor();
                Console.Write(" ");
                Console.ForegroundColor = pegList[answer[a]].TextColor;
                Console.BackgroundColor = pegList[answer[a]].PegColor;
                Console.Write(" {0} ", pegSymbol);
                Console.ResetColor();
                Console.Write(" ");
            }


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("        CorrectAnswer");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Gets the list of peg colors based on the max pegs in this game
        /// Colors are taken from the peg list in order
        /// </summary>
        /// <param name="maxPegs">Maximum number of pegs in this game</param>
        /// <param name="pegList">List of peg color options</param>
        /// <returns>String[] of the colors available in this game. Null if inavlid params are past</returns>
        public static List<string> GetColorOptions(int maxPegs, List<Peg> pegList)
        {
            
            if(maxPegs <= pegList.Count) {
                List<string> colorOptions = new List<string>();
                for (int color = 0; color < maxPegs; color++)
                {
                    colorOptions.Add(pegList[color].PegColor.ToString());
                }
                return colorOptions;
            }

            return null;
        }

        /// <summary>
        /// Shows the pegs the user has chosen so far while giving an answer
        /// </summary>
        /// <param name="attempt">The current attempt being built</param>
        /// <param name="pegList">List of possible peg colors</param>
        public static void ShowChosenPegs(Attempt attempt, List<Peg> pegList)
        {
            StringBuilder pegsChosen = new StringBuilder();
            Console.Write("Answers so far: ");

            for (int i = 0; i < attempt.AttemptList.Count;i++)
            {
                Peg peg = pegList[attempt.AttemptList[i]];

                Console.ForegroundColor = peg.TextColor;
                Console.BackgroundColor = peg.PegColor;
                Console.Write("{0}", peg.PegColor.ToString());
                Console.ResetColor();
                if(i < attempt.AttemptList.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Propmpts the user for an integer between min and max. Will repropt if incorrect input.
        /// </summary>
        /// <param name="message">Message to show the user</param>
        /// <param name="min">Minimum value this answer can be</param>
        /// <param name="max">Maximum value this answer can be</param>
        /// <returns>Int the user typed</returns>
        public static int GetConsoleInt(string message, int min, int max)
        {
            bool success = false;

            int typedValue;
            do
            {
                Console.Write(message);
                //Attempt to parse it.
                success = int.TryParse(Console.ReadLine(), out typedValue);

                //if parse was success, validate its in range. If any fail, it will stop evaluating
                success = success && typedValue >= min && typedValue <= max;

                //Check if all was good.
                if (!success)
                {
                    Console.WriteLine("You entered an invalid value. Must be between {0} and {1} and a valid integer.", min, max);
                }

            } while (!success);

            return typedValue;
        }

        /// <summary>
        /// Presents a menu based on the array of items passed in. Numbers each one. Returns the number of the chosen menu item
        /// </summary>
        /// <param name="items">List of items to display in the menu</param>
        /// <returns>The number of the chosen menu item</returns>
        public static int GetConsoleMenu(List<string> items)
        {
            if (items != null && items.Count > 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine("{0} - {1}", i + 1, items[i]);
                }

                bool success;
                int menuChoice;
                do
                {
                    Console.Write("Choose a menu item: ");
                    success = int.TryParse(Console.ReadLine(), out menuChoice);
                    success = success && menuChoice >= 1 && menuChoice <= items.Count;
                } while (!success);

                return menuChoice;
            }

            return -1;
        }

        /// <summary>
        /// You dirty cheat! See what the answer is before you play.
        /// </summary>
        /// <param name="answer">Array of correct answer indexes</param>
        /// <param name="pegList">List of possible peg colors</param>
        public static void Cheat(List<int> answer, List<Peg> pegList)
        {
            for (int a = 0; a < answer.Count; a++)
            {
                Console.ResetColor();
                Console.Write(" ");
                Console.ForegroundColor = pegList[answer[a]].TextColor;
                Console.BackgroundColor = pegList[answer[a]].PegColor;
                Console.Write(" C ");
                Console.ResetColor();
                Console.Write(" ");
            }


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("        CHEAT!");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Press a key when you have memorized it....");
            Console.ReadLine();
        }
    }
}
