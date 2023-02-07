using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    class Strings
    {
        public static void DoItDangIt()
        {
            string strRando = "Neumont College of Computer Science";

            Console.WriteLine(strRando);
            Console.WriteLine("Length: {0}", strRando.Length);
            Console.WriteLine("Contains 'of': {0}", strRando.Contains("of"));
            int intIndex = strRando.IndexOf("of");
            Console.WriteLine("IndexOf: {0}", intIndex != -1 ? intIndex.ToString() : "Not Found");
            Console.WriteLine("Remove: {0}", strRando.Remove(intIndex, 6));
            Console.WriteLine(strRando);

            //all these operations return a new sting. It does not change the original string.
            //Reason for this is string is immutable. It cannot be changed. New string is always created.

            StringBuilder sb = new StringBuilder("Beginning of string");
            sb.Append(" It is really,");
            sb.Append(" really,");
            sb.Append(" neat!");
            sb.Remove(10, 5);
            sb.Replace("neat", "cool");
            Console.WriteLine($"StringBuilder: {sb.ToString()}");

        }
    }
}
