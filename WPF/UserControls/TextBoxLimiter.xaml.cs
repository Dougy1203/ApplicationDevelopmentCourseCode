using System;
using System.Collections.Generic;
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

namespace WPF.UserControls
{
    /// <summary>
    /// Interaction logic for TextBoxLimiter.xaml
    /// </summary>
    public partial class TextBoxLimiter : UserControl
    {
        public string Title { get; set; }
        public int MaxLength { get; set; }
        public string TitleWidth { get; set; } = "Auto";
        public TextBoxLimiter()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
