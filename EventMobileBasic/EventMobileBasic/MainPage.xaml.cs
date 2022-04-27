using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EventMobileBasic
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<EventDto> events = new ObservableCollection<EventDto>();

        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            var eventApi = DependencyService.Get<EventApiService>();
            var evenements = await eventApi.GetEventsAsync();
         
        }
    }
}
