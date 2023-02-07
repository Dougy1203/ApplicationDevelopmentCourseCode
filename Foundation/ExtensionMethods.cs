using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    public static class ExtensionMethods
    {
        public static void Execute()
        {
            string strMsg = "Havarti Cheese";
            Console.WriteLine("Size of {0} is {1}", strMsg, strMsg.Length);
            Console.WriteLine("Is '{0}' first letter capitalized? {1}", strMsg, strMsg.IsFirstCap());
            Console.WriteLine(strMsg.AppendToEnd(" is the best cheese in the world."));

        }
    }
    public static class StringHelper
    {
        public static bool IsFirstCap(this string strIncoming)
        {
            return char.IsUpper(strIncoming[0]);
        }

        public static string AppendToEnd(this string incoming, string append)
        {
            return incoming + append;
        }
    }
}
