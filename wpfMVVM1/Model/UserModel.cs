using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Haley.Models;
using Haley.Abstractions;
using Haley.MVVM;

namespace wpfMVVM1.Model
{
    public class UserModel : ChangeNotifier
    {
            // ctor here
            public UserModel() { }
            private string _Username;
            public string Username
            {
                get { return _Username; }
                set { _Username = value; OnPropertyChanged(nameof(Username)); }
            }

            private string _Usernumber;
            public string Usernumber
        {
                get { return _Usernumber; }
                set { _Usernumber = value; OnPropertyChanged(nameof(Usernumber)); }
            }

            private string _Level;
            public string Level
        {
                get { return _Level; }
                set { _Level = value; OnPropertyChanged(nameof(Level)); }
            }

        }
    }