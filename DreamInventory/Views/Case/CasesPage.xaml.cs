using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        public string sortQuery = "";
        public string searchQuery = "";
        CaseViewModel newCaseViewModel = new CaseViewModel();

        public CasesPage()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.macOS)
            {
                MobileHeaderBar.IsVisible = false;
                DesktopHeaderBar.IsVisible = true;
            }
            else
            {
                MobileHeaderBar.IsVisible = true;
                DesktopHeaderBar.IsVisible = false;
            }

            previousButton.IsVisible = false;
            previousButtonMob.IsVisible = false;
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
            BindingContext = newCaseViewModel.GetCaseList(pageNumber).cases;
            base.OnAppearing();

        }

        void NextButton_Clicked(System.Object sender, System.EventArgs e)
        {
            pageNumber += 1;
            var apiData = newCaseViewModel.GetCaseList(pageNumber);
            long totalPages = (apiData.TotalCount/ pageSize) + 1;

            if(totalPages == pageNumber)
            {
                nextButton.IsVisible = false;
                nextButtonMob.IsVisible = false;
            }

            if (pageNumber > 1)
            {
                previousButton.IsVisible = true;
                previousButtonMob.IsVisible = true;
            }

            BindingContext = apiData.cases;
        }

        void PreviousButton_Clicked(System.Object sender, System.EventArgs e)
        {
            nextButton.IsVisible = true;
            nextButtonMob.IsVisible = true;
            if (pageNumber == 2)
            {
                previousButton.IsVisible = false;
                previousButtonMob.IsVisible = false;
            }
            pageNumber -= 1;

            BindingContext = newCaseViewModel.GetCaseList(pageNumber).cases;
        }

        void TableHeader_Tapped(System.Object sender, System.EventArgs e)
        {
            var temp = ((Label)sender);
            string CurrentElementText = temp.Text;
            CurrentElementText = Regex.Replace(CurrentElementText, @"\s+", "");

            if (sortQuery == "" || (!sortQuery.Contains("_asc") && !sortQuery.Contains("_dsc")) || !sortQuery.Contains(CurrentElementText))
                sortQuery = CurrentElementText + "_asc";
            else if (sortQuery.Contains("asc"))
                sortQuery = CurrentElementText + "_dsc";
            else
                sortQuery = "";

            BindingContext = newCaseViewModel.GetCaseList(pageNumber, sortQuery, searchQuery).cases;
        }

        void search_event(System.Object sender, System.EventArgs e)
        {
            var temp = ((Entry)sender);
            searchQuery = temp.Text;
            BindingContext = newCaseViewModel.GetCaseList(pageNumber, sortQuery, searchQuery).cases;
        }
    }
}
