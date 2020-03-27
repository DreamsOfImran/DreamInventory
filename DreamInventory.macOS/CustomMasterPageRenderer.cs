using System;
using DreamInventory;
using DreamInventory.macOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer(typeof(CustomMasterPage), typeof(CustomMasterPageRenderer))]
namespace DreamInventory.macOS
{
    public class CustomMasterPageRenderer : MasterDetailPageRenderer
    {
        protected override double MasterWidthPercentage => 0.2;
    }
}