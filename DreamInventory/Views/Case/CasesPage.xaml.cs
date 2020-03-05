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
        CaseApiServices caseApiServices = new CaseApiServices();
        public CasesPage()
        {
            InitializeComponent();

            BindingContext = caseApiServices.GetCases();
        }

        async void NewCase_Tapped(System.Object sender, System.EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewCasePage());
        }
    }
}
