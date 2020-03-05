using System;
using System.Collections.Generic;
using DreamInventory.ViewModels;
using Xamarin.Forms;

namespace DreamInventory
{
    public partial class PlaintiffsPage : ContentPage
    {
        public PlaintiffsPage()
        {
            InitializeComponent();

            BindingContext = new PlaintiffsViewModel();
        }
    }
}
