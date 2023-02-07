using System;
using System.Collections.Generic;
using MasterMindLibrary;


namespace MasterMind
{
    class Program
    {
        static List<Peg> pegList = new List<Peg>()
        {
            new Peg(ConsoleColor.White, ConsoleColor.Red),
            new Peg(ConsoleColor.White, ConsoleColor.Blue),
            new Peg(ConsoleColor.Black, ConsoleColor.Green),
            new Peg(ConsoleColor.Black, ConsoleColor.Yellow),
            new Peg(ConsoleColor.Black, ConsoleColor.Cyan),
            new Peg(ConsoleColor.White, ConsoleColor.Magenta),
            new Peg(ConsoleColor.White, ConsoleColor.DarkGray),
            new Peg(ConsoleColor.White, ConsoleColor.DarkRed)
        };

        static void Main(string[] args)
        {
            List<Attempt> allAttempts = new List<Attempt>();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to Mastermind!");
            Console.ResetColor();

            //ask for difficulty
            Console.WriteLine("Choose Difficulty");
            int difficulty = MMLib.GetConsoleMenu(new List<string> { "Easy: 4 Colors", "Medium: 6 Colors", "Hard: 8 Colors" });

            //ask for maxTurns of turns to guess it
            int maxTurns = MMLib.GetConsoleInt("How many attempts (1-50)?", 1, 50);

            //store the maxPegs based on difficulty
            int maxPegs = (difficulty * 2) + 2; // 4 | 6 | 8

            //Generate an answer
            List<int> answer = MMLib.GenerateAnswer(maxPegs);

            //show cheat? 
            MMLib.Cheat(answer, pegList);

            bool gameWon = false;

            ////////////////////////////////////////////////////
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("Stuff");
            //Conosle.ResetColor();
            ////////////////////////////////////////////////////

            //loop while !gameWon && maxTurns != 0
            do
            {
                //  get user attempt
                Attempt userAttempt = GetAttemptFromUser(maxPegs, allAttempts, maxTurns);
                //  Check the attempt for a correct guess
                CheckAttempt(userAttempt, answer);
                //  add the attempt to the attempt list
                allAttempts.Add(userAttempt);
                //  determin if the game has been won or not
                gameWon = userAttempt.CorrectAnswerCount == maxPegs;
            //  reduce the maxTurns
                maxTurns--;
            } while (!gameWon && maxTurns != 0);

            //If won, display Game Won!
            if (gameWon)
            {
                Console.WriteLine("Congratulations! You Won the Game!!");
            }
            //If lost, show game loss
            //show the correct answer
            if (maxTurns == 0)
            {
                Console.WriteLine("Sadly You Weren't Able to Figure it Out! Try Again!!");
                for (int a = 0; a < answer.Count; a++)
                {
                    Console.ResetColor();
                    Console.Write(" ");
                    Console.ForegroundColor = pegList[answer[a]].TextColor;
                    Console.BackgroundColor = pegList[answer[a]].PegColor;
                    Console.Write(" ");
                    Console.ResetColor();
                    Console.Write(" ");
                }
            }
            
        }

        static Attempt GetAttemptFromUser(int maxPegs, List<Attempt> allAttempts, int maxTurns)
        {
            //Create a new Attempt
            Attempt attempt = new Attempt();
            //Get color options based on maxPegs
            List<string> ColorOptions = MMLib.GetColorOptions(maxPegs, pegList);
            //Loop of # of pegs they need to choose
            for (int i = 0; i < maxPegs; i++)
            {
                //      clear console
                Console.Clear();
                //      Display # of attempts left
                Console.WriteLine(maxTurns);
                //      Show all previous attempts
                MMLib.ShowAttempts(allAttempts, pegList, " ");
                //      Show pegs they have chosen already in this attempt
                MMLib.ShowChosenPegs(attempt, pegList);
                //      Ask them to pick a peg color from a menu of options
                int chosenPeg = MMLib.GetConsoleMenu(MMLib.GetColorOptions(maxPegs, pegList));
                //      Add the chosen peg to the Attempt.AttemptList
                attempt.AttemptList.Add(chosenPeg-1);            
            }

            //Return the attempt when done

            return attempt;
        }


        static void CheckAttempt(Attempt attempt, List<int> answer)
        {
            //Check the attempt.AttemptList to see if they got a match to the answer
            for (int i = 0; i < attempt.AttemptList.Count; i++)
            {
                if (attempt.AttemptList[i] == answer[i])
                {
                    //If a peg is correct, increment the attempt.CorrectAnswerCount
                    attempt.CorrectAnswerCount++;
                }
            }
        }
    }
}
