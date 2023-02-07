using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindLibrary
{
    public class Peg
    {
        public ConsoleColor TextColor { get; set; }
        public ConsoleColor PegColor { get; set; }

        public Peg(ConsoleColor textColor, ConsoleColor pegColor)
        {
            this.TextColor = textColor;
            this.PegColor = pegColor;
        }
    }
}
