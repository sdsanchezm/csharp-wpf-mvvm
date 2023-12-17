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
using UserControl1.ViewModels;

namespace UserControl1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            TextViewModel model1 = new TextViewModel();
            DataContext = model1;
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            LabelViewModel model1 = new LabelViewModel();
            DataContext = model1;
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            DataGridViewModel model1 = new DataGridViewModel();
            DataContext = model1;
        }

        private void bt4_Click(object sender, RoutedEventArgs e)
        {
            StackPanelViewModel model1 = new StackPanelViewModel();
            DataContext = model1;
        }
    }
}
