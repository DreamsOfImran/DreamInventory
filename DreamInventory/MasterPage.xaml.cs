using System;
using System.Collections.Generic;
using DreamInventory.Views.Case;
using DreamInventory.Views.Defendant;
using DreamInventory.Views.Plaintiff;

using Xamarin.Forms;

namespace DreamInventory
{
    public partial class MasterPage : CustomMasterPage
    {
        public MasterPage()
        {
            InitializeComponent();

            Detail = new NavigationPage(new CasesPage());

            if (Device.RuntimePlatform == Device.macOS)
            {
                MobileMenu.IsVisible = false;
                DesktopMenu.IsVisible = true;
            }
            else
            {
                MobileMenu.IsVisible = true;
                DesktopMenu.IsVisible = false;
            }
        }

        void Cases_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new CasesPage());
            CasesMenuTitle.BackgroundColor = Color.FromHex("#4a69ff");
            CasesMenuLabel.TextColor = Color.White;
            CasesMenuLabel.FontAttributes = FontAttributes.Bold;

            DefendantsMenuTitle.BackgroundColor = Color.Transparent;
            DefendantsMenuLabel.TextColor = Color.FromHex("#575757");
            DefendantsMenuLabel.FontAttributes = FontAttributes.None;

            PlaintiffsMenuTitle.BackgroundColor = Color.Transparent;
            PlaintiffsMenuLabel.TextColor = Color.FromHex("#575757");
            PlaintiffsMenuLabel.FontAttributes = FontAttributes.None;
        }

        void Plaintiffs_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new PlaintiffsPage());
            PlaintiffsMenuTitle.BackgroundColor = Color.FromHex("#4a69ff");
            PlaintiffsMenuLabel.TextColor = Color.White;
            PlaintiffsMenuLabel.FontAttributes = FontAttributes.Bold;

            CasesMenuTitle.BackgroundColor = Color.Transparent;
            CasesMenuLabel.TextColor = Color.FromHex("#575757");
            CasesMenuLabel.FontAttributes = FontAttributes.None;

            DefendantsMenuTitle.BackgroundColor = Color.Transparent;
            DefendantsMenuLabel.TextColor = Color.FromHex("#575757");
            DefendantsMenuLabel.FontAttributes = FontAttributes.None;
        }
        void Defendants_Tapped(object sender, EventArgs e)
        {
            IsPresented = false;
            Detail = new NavigationPage(new DefendantsPage());
            DefendantsMenuTitle.BackgroundColor = Color.FromHex("#4a69ff");
            DefendantsMenuLabel.TextColor = Color.White;
            DefendantsMenuLabel.FontAttributes = FontAttributes.Bold;

            CasesMenuTitle.BackgroundColor = Color.Transparent;
            CasesMenuLabel.TextColor = Color.FromHex("#575757");
            CasesMenuLabel.FontAttributes = FontAttributes.None;

            PlaintiffsMenuTitle.BackgroundColor = Color.Transparent;
            PlaintiffsMenuLabel.TextColor = Color.FromHex("#575757");
            PlaintiffsMenuLabel.FontAttributes = FontAttributes.None;
        }
    }
}
