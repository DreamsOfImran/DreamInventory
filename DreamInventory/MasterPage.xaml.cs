﻿using System;
using System.Collections.Generic;
using DreamInventory.Views.Case;
using DreamInventory.Views.Defendant;
using DreamInventory.Views.Plaintiff;

using Xamarin.Forms;

namespace DreamInventory
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();

            Detail = new NavigationPage(new CasesPage());
        }

        void Cases_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new CasesPage());
        }

        void Plaintiffs_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new PlaintiffsPage());
        }
        void Defendants_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new DefendantsPage());
        }
    }
}
