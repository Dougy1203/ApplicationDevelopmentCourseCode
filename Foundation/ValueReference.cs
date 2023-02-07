using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    class ValueReference
    {
        public static void Execute()
        {
            //Value Types
            int v1 = 10;
            int v2 = v1;
            Console.WriteLine("Value type v1: {0}", v1);
            Console.WriteLine("Value type v2: {0}", v2);

            v1 = 5;
            Console.WriteLine("Value type v1: {0}", v1);
            Console.WriteLine("Value type v2: {0}", v2);

            //Reference Types
            int[] aryNumbers1 = new int[] { 1, 2, 3 };
            int[] aryNumbers2 = aryNumbers1;
            Console.WriteLine("Ref type v1: {0}", String.Join(", ", aryNumbers1));
            Console.WriteLine("Ref type v2: {0}", String.Join(", ", aryNumbers2));

            aryNumbers1[0] = 5;
            Console.WriteLine("Ref type v1: {0}", String.Join(", ", aryNumbers1));
            Console.WriteLine("Ref type v2: {0}", String.Join(", ", aryNumbers2));
        }

        struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void Write()
            {
                Console.WriteLine("{0} - {1}", x, y);//String format
                //Console.WriteLine($"{x} - {y}"); //String interpretation
                //Console.WriteLine(x + " - " + y); //String concat
            }
        }
    }
}
