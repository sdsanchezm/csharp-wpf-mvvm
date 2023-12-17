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

namespace UserControl1.Views.UserControls
{
    /// <summary>
    /// Interaction logic for DataGridUserControl.xaml
    /// </summary>
    public partial class DataGridUserControl : UserControl
    {
        public DataGridUserControl()
        {
            InitializeComponent();
        }

        class Person
        {
            public int Id { get; set; }
            public string PersonName { get; set; }
            public int PersonNumber { get; set; }
        }

        private void dataGrid1_loaded(object sender, RoutedEventArgs e)
        {
            List<Person> listOfPersons = new List<Person>();
            listOfPersons.Add(new Person {  Id = 1, PersonName = "Jamecho", PersonNumber = 84 });
            listOfPersons.Add(new Person {  Id = 2, PersonName = "Tiche", PersonNumber = 42 });
            listOfPersons.Add(new Person {  Id = 3, PersonName = "Jara", PersonNumber = 63 });
            dataGrid1.ItemsSource = listOfPersons;
        }

    }
}
