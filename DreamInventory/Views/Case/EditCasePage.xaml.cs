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

            BindingContext = caseObject;
        }
    }
}
