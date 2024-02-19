using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ButtonsInterface.ViewModel
{
    public partial class NavigationViewModel : ObservableObject
    {
        public NavigationViewModel() { PageID = PageId.BluePage; Text1 = "asd"; }

        private PageId _pageId;
        public PageId PageID
        { 
            get { return _pageId; }
            set { SetProperty(ref _pageId, value); }
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
