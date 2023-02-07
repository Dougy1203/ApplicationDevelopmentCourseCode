using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    class Arrays
    {
        public static void BeginIt()
        {
            int[] myArray1 = new int[3];
            myArray1[0] = 55;
            myArray1[1] = 125;
            myArray1.SetValue(23, 2);
            //Int Array defaults empty to zero/0 other arrays default to null

            int[] myArray2 = { 1, 2, 3, 4 };
            int[] myArray3 = new int[] { 1, 2, 3, 4 };

            for (int i = 0; i < myArray2.Length; i++)
            {
                Console.Write("{0} ", myArray2[i]);
            }
            Console.WriteLine();

            //Array to allow multiple types
            //everyting in C# is derived from object
            object[] myThings = new object[] { 10, "Bob", 10.4f };

            //multi dimesnion arrays
            //grid based rows and columns
            string[,] alphabet = new string[2, 2] { { "A", "B" }, { "C", "D" } };

            //GetLength(0) is row
            //GetLength(1) is Column
            for (int row = 0; row < alphabet.GetLength(0); row++)
            {
                for (int column = 0; column < alphabet.GetLength(1); column++)
                {
                    Console.Write("{0} ", alphabet[row, column]);
                }
                Console.WriteLine();
            }

            int[] aryNums = { 1, 2, 3, 4, 5, 6 };
            WriteArray(aryNums);
            //two dots are the range from beginning to end what you want to slice
            //This is exclusive. It does not include index listed
            //first/last number not required if you want to start from beginning or go until end
            WriteArray(aryNums[..3]);
            WriteArray(aryNums[1..4]);
            WriteArray(aryNums[4..]);

            //You can reverse arrays
            ////Array.Reverse(aryNums);
            
            //You can Sort Arrays
            Array.Sort(aryNums);
            WriteArray(aryNums);

            Console.WriteLine("Find index of 6: {0}", Array.IndexOf(aryNums, 6));


            //Find all numbers less than 4
            //Takes a method that returns a true/false (predicate)
            //Array.Find finds first instance
            Console.Write("All Numbers less than 4: ");
            WriteArray(Array.FindAll(aryNums, LessThanFour));


            //Jagged Array
            //could define rows, but columns coudl be varying sizes
            //define row size, but not columns.
            //maybe useful for bar chart data?
            int[][] jagged = new int[3][];

            jagged[0] = new int[] { 1, 2, 3, 4 };
            jagged[1] = new int[] { 5, 6, 7 };
            jagged[2] = new int[] { 8, 9, 10, 11, 12, 13 };
        }

        static void WriteArray(int[] values)
        {
            Console.WriteLine(String.Join(", ", values));
            /*for (int i = 0; i < values.Length; i++)
            {
                Console.Write("{0}", values[i]);
            }
            Console.WriteLine();
            */
         
        }

        static bool LessThanFour(int value)
        {
            return value < 4;
        }
    }
}
