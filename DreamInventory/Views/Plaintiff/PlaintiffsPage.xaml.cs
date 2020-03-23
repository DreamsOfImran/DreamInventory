using System;
using System.Collections.Generic;
using DreamInventory.Services;
using DreamInventory.ViewModels;
using Xamarin.Forms;

namespace DreamInventory.Views.Plaintiff
{
    public partial class PlaintiffsPage : ContentPage
    {
        PlaintiffApiService plaintiffApiService = new PlaintiffApiService();
        public PlaintiffsPage()
        {
            InitializeComponent();

            BindingContext = plaintiffApiService.GetPlaintiffs();

            if (Device.RuntimePlatform == Device.macOS)
            {
                MobilePlaintiffsList.IsVisible = false;
                DesktopPlaintiffsList.IsVisible = true;
            }
            else
            {
                MobilePlaintiffsList.IsVisible = true;
                DesktopPlaintiffsList.IsVisible = false;
            }
        }
    }
}
