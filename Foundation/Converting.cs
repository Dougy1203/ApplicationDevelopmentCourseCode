using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    class Converting
    {
        public static void DoIt()
        {
            // Implicit Conversion. A Long can hold any value an Int cant hold...
            int intNum = 22344321;
            long lngBigNum = intNum;

            var c = 'C';
            Console.WriteLine("var type: {0}", c.GetType());

            //Explicit Conversion. 
            //if a conversion cannot be made without a risk of losing information, the compiler requires thaty you perform an explicit conversion, which is calle a cast
            //A cast is a way of explicitly informing the compiler that you inted to make the conversion and that you are aware that data loss might occur, or the cast may fail at runtime. 
            double dbl = 1234.7;
            int intA;
            intA = (int)dbl;
            System.Console.WriteLine(intA);

            //int intWasString = "5";
            String strNum = "5";
            int intResult = 0;
            intResult = int.Parse(strNum);
            Console.WriteLine("Parse: {0} {1}", intResult, intResult.GetType());

            bool bSuccess = int.TryParse(strNum, out intResult);
            Console.WriteLine(strNum + " converts to int? " + bSuccess);

        }

        public static bool IsNumeric(string strNumber)
        {
            double dblIsNumber;
            return double.TryParse(strNumber, out dblIsNumber);
        }
    }
}
