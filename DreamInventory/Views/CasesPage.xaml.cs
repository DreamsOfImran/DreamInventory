using System;
using System.Collections.Generic;
using DreamInventory.ViewModels;
using Xamarin.Forms;

namespace DreamInventory
{
    public partial class CasesPage : ContentPage
    {
        public CasesPage()
        {
            InitializeComponent();

            BindingContext = new CasesViewModel();
        }
    }
}
