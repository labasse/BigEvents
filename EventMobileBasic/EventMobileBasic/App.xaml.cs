using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventMobileBasic
{
    public partial class App : Application
    {
        private HttpClient http = new HttpClient(
#if DEBUG
            new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, certChain, policyErrors) => true
            }
#endif
        );

        public App()
        {
            InitializeComponent();
            DependencyService.RegisterSingleton(
#if DEBUG
                new EventApiService("https://10.0.2.2:7057", http)
#else
                new EventApiService("https://myevents-api.example.com", http)
#endif
            );
            MainPage = new MainPage();
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
