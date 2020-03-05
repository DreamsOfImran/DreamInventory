using System;
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

            //Detail = new NavigationPage(new DashboardPage());
        }

        void Cases_Tapped(System.Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new CasesPage());
        }

        void Plaintiffs_Tapped(System.Object sender, System.EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new PlaintiffsPage());
        }
        void Defendants_Tapped(System.Object sender, System.EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new DefendantsPage());
        }
    }
}
