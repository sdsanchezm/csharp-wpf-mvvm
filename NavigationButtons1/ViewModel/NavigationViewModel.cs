using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NavigationButtons1.ViewModel
{
    public partial class NavigationViewModel : ObservableObject
    {
        public NavigationViewModel() { PageID = PageId.UserPage; Text1 = "Text ok..."; }

        private PageId _pageID;
        public PageId PageID
        {
            get { return _pageID; }
            set { SetProperty(ref _pageID, value); }
        }

        private string _text1;
        public string Text1
        {
            get { return _text1; }
            set { SetProperty(ref _text1, value); }
        }

        public ICommand UIChangePage => new RelayCommand<PageId>(ChangePage);

        void ChangePage(PageId newPage)
        {
            PageID = newPage;
        }

    }
}
