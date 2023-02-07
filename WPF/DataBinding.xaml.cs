using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for DataBinding.xaml
    /// </summary>
    public partial class DataBinding : Window
    {
        List<Student> students = new List<Student>();
        //ObservableCollection<Student> students = new ObservableCollection<Student>();
        public DataBinding()
        {
            InitializeComponent();
            DataContext = this;

            //Manually Setting a binding in C#
            Binding binding = new Binding("Text");
            binding.Source = txtValue;
            txtData.SetBinding(TextBlock.TextProperty, binding);
            students.Add(new Student() { Id = 1, Name = "Rob1" });
            students.Add(new Student() { Id = 2, Name = "Bob2" });
            students.Add(new Student() { Id = 3, Name = "Cob3" });
            lstStudents.ItemsSource = students;
        }

        private void btnUpdateSource_Click(object sender, RoutedEventArgs e)
        {
            //Manually Updating/Syncing a Binding
            BindingExpression bindingExpression =
                txtTitle.GetBindingExpression(TextBox.TextProperty);

            bindingExpression.UpdateSource();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int newId = students[students.Count - 1].Id + 1;
            students.Add(new Student() { Id = newId, Name = "Hob" + newId });
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if(lstStudents.SelectedItem != null)
            {
                students.Remove((Student)lstStudents.SelectedItem);
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if(lstStudents.SelectedItem != null)
            {
                ((Student)lstStudents.SelectedItem).Name = "Gigi";
            }
        }
    }

    class Student : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if(name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }    
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
