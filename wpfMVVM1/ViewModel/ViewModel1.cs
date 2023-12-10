using Haley.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpfMVVM1.Model;

namespace wpfMVVM1.ViewModel
{
    internal class ViewModel1 : ChangeNotifier
    {
        // ctor here
        public ViewModel1()
        {
            Users = new ObservableCollection<UserModel>();
            TargetUser = new UserModel();
        }
        
        private UserModel user;
        public UserModel TargetUser
        {
            get { return user; }
            set { user = value; OnPropertyChanged(nameof(TargetUser)); }
        }

        private ObservableCollection<UserModel> _users;
        public ObservableCollection<UserModel> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public void AddUser()
        {
            Users.Add(TargetUser);
            TargetUser = new UserModel();
        }

        public ICommand UserAddCommand => new DelegateCommand(AddUser);
        public ICommand UserDeleteCommand => new DelegateCommand<UserModel>(DeleteUser);

        private void DeleteUser(UserModel obj)
        {
            if (obj == null) return;
            if (!Users.Contains(obj)) return;

            Users.Remove(obj);
        }

    }
}
