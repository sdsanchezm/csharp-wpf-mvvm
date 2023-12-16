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
using crud2WSearch.Models;
using crud2WSearch.ViewModel;

namespace crud2WSearch.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel main1 = new MainViewModel();
            this.DataContext = main1;
        }


        // filter 2
        private void filter2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListOfUsers.Items.Filter = FilterMethod_filter2;
            //var user1 = new User() { Username = "sumadre", Usernumber = "567" };
            //ListOfUsers?.Items.Clear();
            //Console.WriteLine("asd");
        }

        private bool FilterMethod_filter2(object obj)
        {
            var user = (User)obj;
            return user.Username.Contains(filter2.Text, StringComparison.OrdinalIgnoreCase);
        }

        // filter1
        private bool FilterMethod_filter1(object obj)
        {
            var user = (User)obj;
            return user.Username.Contains(filter1.Text, StringComparison.OrdinalIgnoreCase);
        }

        private void filter1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListOfUsers.Items.Filter = FilterMethod_filter1;
        }
    }
}
