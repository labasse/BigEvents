using EventMobileMvvm.Services;
using EventMobileMvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventMobileMvvm.Views
{
    public partial class NewItemPage : ContentPage
    {
        public EventDto Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}