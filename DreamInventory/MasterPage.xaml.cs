using System;
using System.Collections.Generic;
using DreamInventory.Models;
using DreamInventory.Views.Case;
using DreamInventory.Views.Defendant;
using DreamInventory.Views.Plaintiff;

using Xamarin.Forms;

namespace DreamInventory
{
    public partial class MasterPage : CustomMasterPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MasterPage()
        {
            InitializeComponent();

            menuList = new List<MasterPageItem>();

            // Adding menu items to menuList and you can define title ,page and icon
            menuList.Add(new MasterPageItem() { Title = "Cases", Icon = "home.png", TargetType = typeof(CasesPage) });
            menuList.Add(new MasterPageItem() { Title = "Defendants", Icon = "setting.png", TargetType = typeof(DefendantsPage) });
            menuList.Add(new MasterPageItem() { Title = "Plaintiffs", Icon = "help.png", TargetType = typeof(PlaintiffsPage) });
            menuList.Add(new MasterPageItem() { Title = "LogOut", Icon = "logout.png", TargetType = typeof(CasesPage) });

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CasesPage)));
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
    //    InitializeComponent();

    //    Detail = new NavigationPage(new CasesPage());

    //    if (Device.RuntimePlatform == Device.macOS)
    //    {
    //        MobileMenu.IsVisible = false;
    //        DesktopMenu.IsVisible = true;
    //    }
    //    else
    //    {
    //        MobileMenu.IsVisible = true;
    //        DesktopMenu.IsVisible = false;
    //    }
    //}

    //void Cases_Tapped(object sender, EventArgs e)
    //{
    //    IsPresented = false;
    //    Detail = new NavigationPage(new CasesPage());
    //}

    //void Plaintiffs_Tapped(object sender, EventArgs e)
    //{
    //    IsPresented = false;
    //    Detail = new NavigationPage(new PlaintiffsPage());
    //}
    //void Defendants_Tapped(object sender, EventArgs e)
    //{
    //    IsPresented = false;
    //    Detail = new NavigationPage(new DefendantsPage());
    //}
    //}
}
