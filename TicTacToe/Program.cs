using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[3, 3];
            Console.WriteLine("What is Player 1's name?");
            string player1 = Console.ReadLine();
            Console.WriteLine("What is Player 2's name?");
            string player2 = Console.ReadLine();

            char[] symbols = { 'X', 'O' };

            bool IsGameDone = false;

            //Who's turn currently
            int turns = 0;
            int maxTurns = 9; //0 - 9


            void WriteBoard() 
            {
                Console.WriteLine();
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int column = 0; column < board.GetLength(1); column++)
                    {
                        Console.Write(" {0} ", board[row, column]);
                        Console.Write("|");                
                    }
                    Console.WriteLine();
                    Console.Write("----------");
                    Console.WriteLine();
                }
            }

            static bool CheckWin(char[,] board)
            {
                //Horizontal Check
                if (board[0, 0] == 'X' && board[0, 1] == 'X' && board[0, 2] == 'X')
                    return true;
                if (board[1, 0] == 'X' && board[1, 1] == 'X' && board[1, 2] == 'X')
                    return true;
                if (board[2, 0] == 'X' && board[2, 1] == 'X' && board[2, 2] == 'X')
                    return true;
                if (board[0, 0] == 'O' && board[0, 1] == 'O' && board[0, 2] == 'O')
                    return true;
                if (board[1, 0] == 'O' && board[1, 1] == 'O' && board[1, 2] == 'O')
                    return true;
                if (board[2, 0] == 'O' && board[2, 1] == 'O' && board[2, 2] == 'O')
                    return true;

                //Vertical ChecK
                if (board[0, 0] == 'X' && board[1, 0] == 'X' && board[2, 0] == 'X')
                    return true;
                if (board[0, 1] == 'X' && board[1, 1] == 'X' && board[2, 1] == 'X')
                    return true;
                if (board[0, 2] == 'X' && board[1, 2] == 'X' && board[2, 2] == 'X')
                    return true;
                if (board[0, 0] == 'O' && board[1, 0] == 'O' && board[2, 0] == 'O')
                    return true;
                if (board[0, 1] == 'O' && board[1, 1] == 'O' && board[2, 1] == 'O')
                    return true;
                if (board[0, 2] == 'O' && board[1, 2] == 'O' && board[2, 2] == 'O')
                    return true;

                //Diagonal Check
                if (board[0, 0] == 'X' && board[1, 1] == 'X' && board[2, 2] == 'X')
                    return true;
                if (board[0, 0] == 'O' && board[1, 1] == 'O' && board[2, 2] == 'O')
                    return true;
                if (board[2, 0] == 'X' && board[1, 1] == 'X' && board[0, 2] == 'X')
                    return true;
                if (board[2, 0] == 'O' && board[1, 1] == 'O' && board[0, 2] == 'O')
                    return true;
                return false;
            }
            
            bool player1Turn = false;
            bool player2Turn = false;
            int playerRow;
            int playerColumn;

            do
            {
                player1Turn = true;
                do
                {
                    Console.WriteLine(player1 + " Pick a Row 1-3");
                    playerRow = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Your selection was {playerRow}, what Column would you like to play on 1-3?");
                    playerColumn = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Your selection was {playerColumn}");
                    if (!board[playerRow - 1, playerColumn - 1].Equals(symbols[0]) && !board[playerRow - 1, playerColumn - 1].Equals(symbols[1]))
                    {
                        board[playerRow - 1, playerColumn - 1] = symbols[0];
                        turns++;
                        player1Turn = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Selection, Try Again");
                    }
                }
                while (player1Turn == true);

                WriteBoard();

                if (CheckWin(board))
                {
                    Console.WriteLine($"{player1} Wins!!! They Won in {turns} turns!");
                    IsGameDone = true;
                    break;
                }
                else if (turns == maxTurns)
                {
                    Console.WriteLine($"Cats Game! Both {player1} and {player2} failed to beat their opponent");
                    IsGameDone = true;
                    break;
                }

                player2Turn = true;
                do
                {
                    Console.WriteLine(player2 + " Pick a Row 1-3");
                    playerRow = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Your selection was {playerRow}, what Column would you like to play on 1-3?");
                    playerColumn = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Your selection was {playerColumn}");
                    if (!board[playerRow - 1, playerColumn - 1].Equals(symbols[0]) && !board[playerRow - 1, playerColumn - 1].Equals(symbols[1]))
                    {
                        board[playerRow - 1, playerColumn - 1] = symbols[1];
                        turns++;
                        if (CheckWin(board))
                        {
                            Console.WriteLine($"{player2} Wins!!! They Won in {turns} turns!");
                            player2Turn = false;
                            IsGameDone = true;
                            break;
                        }
                        else if (turns == maxTurns)
                        {
                            Console.WriteLine($"Cats Game! Both {player1} and {player2} failed to beat their opponent");
                            player2Turn = false;
                            IsGameDone = true;
                            break;
                        }
                        player2Turn = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Selection, Try Again");
                    }
                }
                while (player2Turn == true);

                WriteBoard();

                if (CheckWin(board))
                {
                    Console.WriteLine($"{player2} Wins!!! They Won in {turns} turns!");
                    IsGameDone = true;
                    break;
                }
                else if (turns == maxTurns)
                {
                    Console.WriteLine($"Cats Game! Both {player1} and {player2} failed to beat their opponent");
                    IsGameDone = true;
                    break;
                }
            }
            while (IsGameDone == false);
        }
    }
}
