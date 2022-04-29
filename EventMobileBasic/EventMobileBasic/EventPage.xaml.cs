using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventMobileBasic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        private EventDto draft = new EventDto() { Title="" };
        public EventPage(EventEntry entry)
        {
            if(entry.IsStandard)
            {
                draft.Title = entry.Event.Title;
                draft.Description = entry.Event.Description;
            }
            BindingContext = draft;
            InitializeComponent();
        }
    }
}