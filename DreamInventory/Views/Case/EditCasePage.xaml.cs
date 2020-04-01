using System;
using System.Collections.Generic;
using DreamInventory.ViewModels;
using Xamarin.Forms;

namespace DreamInventory.Views.Case
{
    public partial class EditCasePage : ContentPage
    {
        public EditCasePage(Cases caseObject)
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.macOS)
            {
                MobileEditCaseForm.IsVisible = false;
                DesktopEditCaseForm.IsVisible = true;
            }
            else
            {
                MobileEditCaseForm.IsVisible = true;
                DesktopEditCaseForm.IsVisible = false;

                if (Device.RuntimePlatform == Device.Android)
                {
                    MobileDescriptionTextarea.BackgroundColor = Color.Transparent;
                }
                else
                {
                    MobileDescriptionTextarea.BorderColor = Color.LightGray;
                }
            }

            BindingContext = caseObject;
        }

        void Cancel_Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
