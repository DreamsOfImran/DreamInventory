using System;
using System.Collections.Generic;
using DreamInventory.Services;
using DreamInventory.ViewModels;
using Xamarin.Forms;

namespace DreamInventory.Views.Defendant
{
    public partial class DefendantsPage : ContentPage
    {
        DefendantApiService defendantApiService = new DefendantApiService();
        public DefendantsPage()
        {
            InitializeComponent();

            BindingContext = defendantApiService.GetDefendants();
        }
    }
}
