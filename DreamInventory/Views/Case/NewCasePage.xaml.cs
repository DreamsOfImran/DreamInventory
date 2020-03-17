using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DreamInventory.Views.Case
{
    public partial class NewCasePage : ContentPage
    {
        public NewCasePage()
        {
            InitializeComponent();

            if(Device.RuntimePlatform == Device.macOS)
            {
                MobileNewCaseForm.IsVisible = false;
                DesktopNewCaseForm.IsVisible = true;
            }
            else
            {
                MobileNewCaseForm.IsVisible = true;
                DesktopNewCaseForm.IsVisible = false;
            }
        }
    }
}
