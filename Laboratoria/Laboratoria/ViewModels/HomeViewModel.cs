using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laboratoria.ViewModels
{
    class HomeViewModel
    {
        INavigation _navigation;
        private ICommand _navigateToDetailsPageCommand;
        public ICommand NavigateToDetailsPageCommand =>
            _navigateToDetailsPageCommand ?? (_navigateToDetailsPageCommand = new Command(NavitageToDetailsPage));

        public HomeViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        private void NavitageToDetailsPage()
        {
            _navigation.PushAsync(new DetailsPage());
        }
    }
}
