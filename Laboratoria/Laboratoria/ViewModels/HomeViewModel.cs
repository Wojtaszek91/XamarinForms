using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
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
            var location = GetLocation();
            Initialize();
        }

        private void NavitageToDetailsPage()
        {
            _navigation.PushAsync(new DetailsPage());
        }

        private void Initialize()
        {

        }





        private static HttpClient GetClientWithHeaders()
        {
            var client = new HttpClient();


            return client;
        }
        private async Task<Location> GetLocation()
        {
            try
            {
                return await Geolocation.GetLastKnownLocationAsync() 
                    ?? await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Low));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
