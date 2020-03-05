using System;
using System.Collections.Generic;
using DreamInventory.ViewModels;
using Xamarin.Forms;

namespace DreamInventory
{
    public partial class DefendantsPage : ContentPage
    {
        public DefendantsPage()
        {
            InitializeComponent();

            BindingContext = new DefendantsViewModel();
        }
    }
}
