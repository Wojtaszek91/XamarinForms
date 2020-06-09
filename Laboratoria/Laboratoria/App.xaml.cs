using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratoria
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new TabMainPage();
            InitializeComponent();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
