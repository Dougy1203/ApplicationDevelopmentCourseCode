using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindLibrary
{
    public class Attempt
    {
        public List<int> AttemptList { get; set; } = new List<int>();

        public int CorrectAnswerCount { get; set; } = 0;

        public Attempt()
        {
           
        }
    }
}
