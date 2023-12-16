using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud2WSearch.Models
{
    public class UserManagement
    {
        public static ObservableCollection<User> _DatabaseUsers = new ObservableCollection<User>() { new User() { Usernumber = "123", Username= "TicheSanc" }, new User { Usernumber = "234", Username= "JamechoSanc" } };

        public static ObservableCollection<User> GetUsers()
        {
            return _DatabaseUsers;
        }


        public static void AddUser(User user)
        {
            _DatabaseUsers.Add(user);
        }
    }
}
