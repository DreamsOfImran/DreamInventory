using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DreamInventory
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();

            Detail = new NavigationPage(new DashboardPage());
        }

        void Cases_Tapped(System.Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new CasesPage());
        }

        void Judgement_Tapped(System.Object sender, System.EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new JudgementPage());
        }
    }
}
