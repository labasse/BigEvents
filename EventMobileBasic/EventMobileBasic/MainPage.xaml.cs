using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace EventMobileBasic
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private readonly ObservableCollection<EventEntry> events = new ObservableCollection<EventEntry>();
        private string erreur = "";
        private Timer alertTimer = new Timer(2000);

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            alertTimer.Elapsed +=(s, e) => {
                Erreur = "";
                alertTimer.Stop();
            };
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
            var entry = (EventEntry)((Element)sender).BindingContext;

            Navigation.PushAsync(new EventPage(entry));
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
                Erreur = ex.Message;
                events.Add(entry);
            }
        }
        public string Erreur
        {
            get => erreur;
            set
            {
                erreur = value;
                alertTimer.Start();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Erreur)));
            }
        }
        public new event PropertyChangedEventHandler PropertyChanged;
    }
}
