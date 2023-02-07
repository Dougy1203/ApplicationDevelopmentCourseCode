using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace CasinoSim
{
    class PlayerInfo
    {

        private string name;
        private int bankAmount;
        private int chipAmount;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int BankAmount
        {
            get { return bankAmount;  }
            set { bankAmount = value; }
        }

        public int ChipAmount
        {
            get { return chipAmount; }
            set { chipAmount = value; }
        }

        public PlayerInfo()
        {
            try
            {
                string playerInfo = File.ReadAllText("playerInfo.txt");
                BankAmount = int.Parse(playerInfo.Split(":")[0]);
                ChipAmount = int.Parse(playerInfo.Split(":")[1]);
            }
            catch (Exception ex)
            {
                File.WriteAllText("playerInfo.txt", "15000:15000");
            }
        }
    }
}
