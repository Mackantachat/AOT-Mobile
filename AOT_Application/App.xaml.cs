using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AOT_Application.Services;
using AOT_Application.Views;
using AOT_Application.Services.api;

namespace AOT_Application
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address 
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.10.127:32768/api/" : "http://localhost:5000";

        //public static bool UseMockDataStore = false;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ApiCriminalPersonDataStore>();
            DependencyService.Register<ApiEventNotifyDataStore>();

            MainPage = new MainPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
