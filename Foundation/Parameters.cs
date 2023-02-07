using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    class Parameters
    {
        public static void Engage()
        {
            int intRef = 7;
            int[] ary = new int[] { 5, 6 };
            string strByVal = "Fred";
            RefTest clsRT = new RefTest();
            clsRT.x = 1;
            int intValue = 66;
            int[] ary2 = new int[2];
            ary.CopyTo(ary2, 0);
            ByValRefTest(ref intRef, strByVal, ary2, clsRT, intValue);
            /*
            Console.WriteLine("INT ByRef: {0}", intRef);
            Console.WriteLine("String ByVal: " + strByVal);
            Console.WriteLine("ary[0]: {0}", ary[0]);
            Console.WriteLine("RefTest: {0}", clsRT.x);
            Console.WriteLine("Int Value: {0}", intValue);
            */

            //Default params
            DefaultParam();
            DefaultParam(50);

            //Create NamedFunction
            //Named Param allows us to change the order or params
            NamedFunction(20, 10);
            NamedFunction(y: 60, x: 15);

        }

        static void DefaultParam(int n = 20)
        {
            //Creates a default set optional param (not required to be passed in)
            Console.WriteLine("Default Param: {0}", n);
        }

        static void NamedFunction(int x, int y)
        {
            Console.WriteLine("NamedParam: {0} - {1}", x, y);
        }

        public class RefTest
        {
            public int x;
        }

        public static void ByValRefTest(ref int xRef, String sVal, int[] ary, RefTest clsRefTest, int intValue)
        {
            xRef = xRef * xRef;
            sVal = "Fanny";
            ary[0] = 10;
            clsRefTest.x = 88;
            intValue = 42;
        }
    }
}
