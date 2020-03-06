using System;
using System.Collections.Generic;
using DreamInventory.Services;
using DreamInventory.ViewModels;
using DreamInventory.Views;
using Xamarin.Forms;

namespace DreamInventory.Views.Case
{
    public partial class CasesPage : ContentPage
    {
        CaseViewModel newCaseViewModel = new CaseViewModel();
        public CasesPage()
        {
            InitializeComponent();

            BindingContext = newCaseViewModel.GetCaseList();
        }

        async void NewCase_Tapped(System.Object sender, System.EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewCasePage());
        }
    }
}
