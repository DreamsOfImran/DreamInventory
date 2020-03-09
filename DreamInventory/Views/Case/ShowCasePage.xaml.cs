using System;
using System.Collections.Generic;
using DreamInventory.ViewModels;
using Xamarin.Forms;

namespace DreamInventory.Views.Case
{
    public partial class ShowCasePage : ContentPage
    {
        CaseViewModel caseViewModel = new CaseViewModel();
        public ShowCasePage(object selectedCase)
        {
            InitializeComponent();

            BindingContext = caseViewModel.SelectedCase(selectedCase);
        }

        void DeleteButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
