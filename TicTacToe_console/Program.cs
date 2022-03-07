using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_console
{
    internal class Program
    {
        static string[,] ticTacToeArray =
            {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            };

        static void Main(string[] args)
        {
            int input = 0;
            bool turns = true;
            int position1 = 0;
            int position2 = 0;
            int moveCount = 0;

            bool isValid = false;

            printoutTicTacToe();
            do
            {
                Console.WriteLine("Please input value [1-9] or -1 to exit!");
                Console.WriteLine("Player {0}: Choose your field!", turns == true ? 1 : 2);
                input = 0;
                isValid = false;

                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (input > 0 && input < 10)
                    {
                        position1 = input / 3;
                        position2 = input % 3 -1;
                        if (position2 == -1)
                        {
                            position1 -= 1;
                            position2 += 3;
                        }

                        if (ticTacToeArray[position1, position2] != "X" && 
                            ticTacToeArray[position1, position2] != "O")
                        {
                            
                            ticTacToeArray[position1, position2] = turns == true ? "X" : "O";
                            isValid = true;
                            moveCount++;
                        }
                        else
                        {
                            Console.WriteLine("Please input correct value!");
                            _ = Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please input correct value!");
                    _ = Console.ReadKey();
                }
                Console.Clear();
                printoutTicTacToe();

                if (isValid==true)
                {
                    if (checkWin() == true)
                    {
                        Console.WriteLine("Player {0} has won!", turns == true ? "1" : "2");                        
                        input = -1;
                    }
                    else
                    {                     
                        if (moveCount >= 9)
                        {
                            Console.WriteLine("Draw game!");
                            input = -1;
                        }
                        else
                        {
                            if (turns == false)
                                turns = true;
                            else
                                turns = false;
                        }
                        
                    }
                }
            } while (input != -1);
            
        }

        public static void printoutTicTacToe()
        {
            for (int i = 0; i < ticTacToeArray.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("   |   |");
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("___|___|___");
                    Console.WriteLine("   |   |");
                }
                for (int j = 0; j < ticTacToeArray.GetLength(1); j++)
                {
                    if (j == 0)
                        Console.Write(" {0} ", ticTacToeArray[i, j]);
                    else
                        Console.Write("| {0} ", ticTacToeArray[i, j]);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("___|___|___");
            Console.WriteLine("");
        }

        public static bool checkWin()
        {
            // match with row line
            if ((ticTacToeArray[0, 0] == ticTacToeArray[0, 1] && ticTacToeArray[0, 0] == ticTacToeArray[0, 2]) ||
                (ticTacToeArray[1, 0] == ticTacToeArray[1, 1] && ticTacToeArray[1, 0] == ticTacToeArray[1, 2]) ||
                (ticTacToeArray[2, 0] == ticTacToeArray[2, 1] && ticTacToeArray[2, 0] == ticTacToeArray[2, 2]) ||
            // match with colum line
                (ticTacToeArray[0, 0] == ticTacToeArray[1, 0] && ticTacToeArray[0, 0] == ticTacToeArray[2, 0]) ||
                (ticTacToeArray[0, 1] == ticTacToeArray[1, 1] & ticTacToeArray[0, 1] == ticTacToeArray[2, 1]) ||
                (ticTacToeArray[0, 2] == ticTacToeArray[1, 2] && ticTacToeArray[0, 2] == ticTacToeArray[2, 2]) ||
            // match witch oblique line
                (ticTacToeArray[0, 0] == ticTacToeArray[1, 1] && ticTacToeArray[0, 0] == ticTacToeArray[2, 2]) ||
                (ticTacToeArray[0, 2] == ticTacToeArray[1, 1] && ticTacToeArray[0, 2] == ticTacToeArray[2, 0])
                )
                return true;            
            else
                return false;

        }
    }
}

