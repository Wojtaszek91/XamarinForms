using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using AutoMapper;
using Xamarin.Forms.Xaml;
using Laboratoria.Models;

namespace Laboratoria
{
    public partial class App : Application
    {
        static StreamReader GetReader(Stream stream) => new StreamReader(stream);
        public static DataBaseContext dbContext { get; set; }
        public static string AirlyApiKey { get; private set; }
        public static string AirlyApiUrl { get; private set; }
        public static string AirlyApiMeasurementUrl { get; private set; }
        public static string AirlyApiInstallationUrl { get; private set; }

        public App()
        {
            InitializeComponent();
            _ = InitializeApp();
         //   _mapper.mapper.Map<Measurements>(new MeasurmentsEntity());
        }

        private async Task InitializeApp()
        {
            await LoadConfiguration();
            MainPage = new TabMainPage();
       //     dbContext = new DataBaseContext();
        }

        private static async Task LoadConfiguration()

        {
            var assembly = Assembly.GetAssembly(typeof(App));
            var dynamicJson = JObject.Parse(await GetReader(assembly.GetManifestResourceStream(assembly.
                GetManifestResourceNames().FirstOrDefault(c => c.Contains("configuration.json")))).
                ReadToEndAsync());

                    AirlyApiKey = dynamicJson["AirlyApiKey"].Value<string>();
                    AirlyApiUrl = dynamicJson["AirlyApiUrl"].Value<string>();
                    AirlyApiMeasurementUrl = dynamicJson["AirlyApiMeasurementUrl"].Value<string>();
                    AirlyApiInstallationUrl = dynamicJson["AirlyApiInstallationUrl"].Value<string>();           
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