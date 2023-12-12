using crud2WSearch.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }




    }
}
