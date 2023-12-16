using crud2WSearch.Commands;
using crud2WSearch.Models;
using crud2WSearch.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace crud2WSearch.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<User> Users1 { get; set; }
        public ICommand ShowAddUserWindowCommand { get; set; }

        public MainViewModel()
        {
            Users1 = UserManagement.GetUsers();
            ShowAddUserWindowCommand = new PopupCommand(ShowUserAddWindow, CanShowUserAddWindow);
        }

        private bool CanShowUserAddWindow(object obj)
        {
            return true;
        }

        private void ShowUserAddWindow(object obj)
        {
            // create a generic window
            var mainWindow = obj as Window;
            // Create a class from the behind class of the xaml
            UserAdd userAddWindow = new UserAdd();
            // set the owner of the add user window
            userAddWindow.Owner = mainWindow;
            // set the center of the window
            userAddWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            // show window
            userAddWindow.Show();
        }

    }
}
