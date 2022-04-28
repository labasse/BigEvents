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
        private ObservableCollection<EventEntry> events = new ObservableCollection<EventEntry>();

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
        }
        public ObservableCollection<EventEntry> Events => events;
        protected override async void OnAppearing()
        {
            try
            {
                var eventApi = DependencyService.Get<EventApiService>();
                var evenements = await eventApi.GetEventsAsync();

                events.Clear();
                events.Add(new EventEntry("(Nouvel évènement)"));
                foreach (var ev in evenements)
                {
                    events.Add(new EventEntry(ev));
                }
            }
            finally
            {
                pleaseWait.IsVisible = false;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private async void SwipeItem_Clicked(object sender, EventArgs e)
        {
            var entry = (EventEntry)((Element)sender).BindingContext;

            events.Remove(entry);
            try
            {
                await DependencyService.Get<EventApiService>().DeleteEventAsync(entry.Event.Id.Value);
            }
            catch(ApiException ex)
            {
                events.Add(entry);
            }
        }
    }
}
