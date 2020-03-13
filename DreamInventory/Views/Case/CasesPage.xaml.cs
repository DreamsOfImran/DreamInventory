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
        public int pageNumber = 1;
        public int pageSize = 10;
        CaseViewModel newCaseViewModel = new CaseViewModel();
        public CasesPage()
        {
            InitializeComponent();

            previousButton.IsVisible = false;
        }

        void NewCase_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewCasePage());
        }

        void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var SelectedCase = e.Item;

            Navigation.PushAsync(new ShowCasePage(SelectedCase));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = newCaseViewModel.GetCaseList(pageNumber).cases;
        }

        void NextButton_Clicked(System.Object sender, System.EventArgs e)
        {
            
            pageNumber += 1;
            var apiData = newCaseViewModel.GetCaseList(pageNumber);
            long totalPages = (apiData.TotalCount/ pageSize) + 1;

            if(totalPages == pageNumber)
            {
                nextButton.IsVisible = false;
            }

            if (pageNumber > 1)
            {
                previousButton.IsVisible = true;
            }

            BindingContext = apiData.cases;
        }

        void PreviousButton_Clicked(System.Object sender, System.EventArgs e)
        {
            nextButton.IsVisible = true;
            if (pageNumber == 2)
            {
                previousButton.IsVisible = false;
            }
            pageNumber -= 1;

            BindingContext = newCaseViewModel.GetCaseList(pageNumber).cases;
        }
    }
}
