﻿using EventMobileMvvm.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace EventMobileMvvm.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}