using crud2WSearch.Commands;
using crud2WSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace crud2WSearch.ViewModel
{
    internal class UserAddViewModel
    {
        public ICommand AddUserCommand { get; set; }
        public string? Username { get; set; }
        public string? Usernumber { get; set; }

        public UserAddViewModel()
        {
            AddUserCommand = new PopupCommand(AddUser);
        }

        private bool CanUserAdd(object obj)
        {
            return true;
        }

        private void AddUser(object obj)
        {
            UserManagement.AddUser(new User() { Username = Username, Usernumber = Usernumber });
        }

    }
}
