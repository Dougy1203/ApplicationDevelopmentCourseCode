using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DungeonsAndDragons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Character character = new Character();
        bool isSaved;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Resources["Age"] = "";
            Resources["Gender"] = "";
            Resources["Class"] = "";
            Resources["Race"] = "";
            Resources["Strength"] = "";
            Resources["Dexterity"] = "";
            Resources["Constitution"] = "";
            Resources["Wisdom"] = "";
            Resources["Intelligence"] = "";
            Resources["Charisma"] = "";
            Resources["SaveState"] = "Save";
            Resources["btnRandom"] = "Random";


            //
            //Gross----- Environment.Exit(0);
            //Nice-------Application.Current.Shutdown();

        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            if (isSaved)
            {
                Resources["Age"] = "";
                Resources["Gender"] = "";
                Resources["Class"] = "";
                Resources["Race"] = "";
                Resources["Strength"] = "";
                Resources["Dexterity"] = "";
                Resources["Constitution"] = "";
                Resources["Wisdom"] = "";
                Resources["Intelligence"] = "";
                Resources["Charisma"] = "";
                Resources["SaveState"] = "Save";
                Resources["btnRandom"] = "Random";
                tboxName.Text = "";
                isSaved = false;
            }
            else
            {
                Random r = new Random();
                character.randomize();
                Resources["Age"] = character._age.ToString();
                Resources["Gender"] = character._gender.ToString();
                Resources["Class"] = character._class.ToString();
                Resources["Race"] = character._race.ToString();
                Resources["Strength"] = r.Next(20).ToString();
                Resources["Dexterity"] = r.Next(20).ToString();
                Resources["Constitution"] = r.Next(20).ToString();
                Resources["Wisdom"] = r.Next(20).ToString();
                Resources["Intelligence"] = r.Next(20).ToString();
                Resources["Charisma"] = r.Next(20).ToString();
            }
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            
            DataTable dt;
            Hashtable ht = new Hashtable();
            string sql;
            long lngreturn;
            
            
            if (tboxName.Text.Equals("") || txtAge.Text.Equals("") || txtClass.Text.Equals("") || txtGender.Text.Equals("") || txtRace.Text.Equals(""))
            {
                MessageBox.Show("Must Fill All Character Information. \n What kind of Character are you making?");
            }
            else if (txtStrength.Text.Equals("") || txtConstitution.Text.Equals("") || txtDexterity.Text.Equals("") ||
                     txtCharisma.Text.Equals("") || txtIntelligence.Text.Equals("") || txtWisdom.Text.Equals(""))
            {
                MessageBox.Show("Must Fill in All Character Stats.");
            }
            else
            {
                sql = $"SELECT Name FROM DnD WHERE Name = '{tboxName.Text}'";
                dt = ExDB.GetDataTable("AwesomeDB", ht, sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Character Name Already Exists, Try Again.");
                }
                else if (dt.Rows.Count == 0)
                {
                    string ages = txtAge.Text;
                    //int age = int.Parse(ages);
                    MessageBox.Show(ages);
                    ht.Add("@Name", tboxName.Text);
                    ht.Add("@Age", int.Parse(lblAge.Text));
                    ht.Add("@Gender", lblGender.Text);
                    ht.Add("@Class", lblClass.Text);
                    ht.Add("@Race", lblRace.Text);
                    ht.Add("@Strength", int.Parse(lblStrength.Text));
                    ht.Add("@Constitution", int.Parse(lblConstitution.Text));
                    ht.Add("@Dexterity", int.Parse(lblDexterity.Text));
                    ht.Add("@Charisma", int.Parse(lblCharisma.Text));
                    ht.Add("@Intelligence", int.Parse(lblIntelligence.Text));
                    ht.Add("@Wisdom", int.Parse(lblWisdom.Text));

                    sql = "INSERT INTO DnD (Name,Age,Gender,Class,Race,Strength,Constitution,Dexterity,Charisma,Intelligence,Wisdom)" + 
                    "VALUES(@Name,@Age,@Gender,@Class,@Race,@Strength,@Constitution,@Dexterity,@Charisma,@Intelligence,@Wisdom)";
                    MessageBox.Show("Made it here");
                    lngreturn = ExDB.ExecuteIt("AwesomeDB", sql, ht);
                    isSaved = true;
                    Resources["SaveState"] = "Saved";
                    Resources["btnRandom"] = "Restart";

                }
            }
            
        }

        private void Saved_OnClick(object sender, RoutedEventArgs e)
        {
            new Saved().Show();
            this.Close();
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }



    class Character : INotifyPropertyChanged
    {
        public enum Gender { Male, Female };
        public enum Race
        {
            Dragonborn, Dwarf, Elf, Gnome, Halfling, Human, Tiefling,
            Leonin, Satyr, Lineages, Fairy, Harengon, Owlin, Arakocra, Genasi, Goliath,
            Asimar, Bugbear, Firbolg, Goblin, Hobgoblin, Kenku, Kobold, Lizardfolk, Orc,
            Tabaxi, Triton, Tortle, Changling, Kalashtar, Shifter, Warforged, Gith, Centaur,
            Loxodon, Minotaur, Vadelken, Verdan, Locathah, Grung
        };
        public enum Class
        {
            Barbarian, Artificer, Sorcerer, Warlock, Wizard, Paladin,
            Rogue, Ranger, Monk, Druid, Fighter, Bard, Cleric
        };

        public string _name;
        public int _age;
        public Gender _gender;
        public Race _race;
        public Class _class;

        public void randomize()
        {
            Random r = new Random();
            _age = r.Next(2001) + 23;
            _gender = (Gender)r.Next(Enum.GetNames(typeof(Gender)).Length);
            _race = (Race)r.Next(Enum.GetNames(typeof(Race)).Length);
            _class = (Class)r.Next(Enum.GetNames(typeof(Class)).Length);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
