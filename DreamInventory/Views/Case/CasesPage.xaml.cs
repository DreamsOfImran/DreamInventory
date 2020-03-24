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
            List<string> sortElements = new List<string>();
            sortElements.Add("Sort by: None");
            sortElements.Add("Sort by: Case No asc");
            sortElements.Add("Sort by: Case No desc");
            sortElements.Add("Sort by: Case Type asc");
            sortElements.Add("Sort by: Case Type desc");
            sortElements.Add("Sort by: Filling Date asc");
            sortElements.Add("Sort by: Filling Date desc");
            sortElements.Add("Sort by: Judge asc");
            sortElements.Add("Sort by: Judge desc");

            InitializeComponent();

            mobilePicker.ItemsSource = sortElements;
            macPicker.ItemsSource = sortElements;

            if (Device.RuntimePlatform == Device.macOS)
            {
                MobileHeaderBar.IsVisible = false;
                DesktopHeaderBar.IsVisible = true;

                MobileCasesList.IsVisible = false;
                DesktopCasesList.IsVisible = true;
            }
            else
            {
                MobileHeaderBar.IsVisible = true;
                DesktopHeaderBar.IsVisible = false;

                MobileCasesList.IsVisible = true;
                DesktopCasesList.IsVisible = false;
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

        void NextButton_Clicked(object sender, EventArgs e)
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

        void PreviousButton_Clicked(object sender, EventArgs e)
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

        void search_event(object sender, EventArgs e)
        {
            var temp = ((Entry)sender);
            searchQuery = temp.Text;
            BindingContext = newCaseViewModel.GetCaseList(pageNumber, sortQuery, searchQuery).cases;
        }

        void SortPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var temp = ((Picker)sender);
            string CurrentElementText = temp.SelectedItem.ToString();
            if (CurrentElementText ==  "None")
            {
                sortQuery = "";
            }
            else if (CurrentElementText.Contains("asc"))
            {
                int index = CurrentElementText.IndexOf("asc");
                CurrentElementText = CurrentElementText.Remove(index, 3);
                CurrentElementText = Regex.Replace(CurrentElementText, @"\s+", "");
                sortQuery = CurrentElementText + "_asc";
            }
            else
            {
                int index = CurrentElementText.IndexOf("desc");
                CurrentElementText = CurrentElementText.Remove(index, 4);
                CurrentElementText = Regex.Replace(CurrentElementText, @"\s+", "");
                sortQuery = CurrentElementText + "_dsc";
            }

            BindingContext = newCaseViewModel.GetCaseList(pageNumber, sortQuery, searchQuery).cases;
        }
    }
}
