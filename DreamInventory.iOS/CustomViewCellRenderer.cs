using System;
using System.Drawing;
using DreamInventory;
using DreamInventory.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomViewCell), typeof(CustomViewCellRenderer))]
namespace DreamInventory.iOS
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            UITableViewCell cell = base.GetCell(item, reusableCell, tv);

            if (cell != null)
            {
                // Disable native cell selection color style - set as *Transparent*
                cell.SelectionStyle = UITableViewCellSelectionStyle.Blue;

                cell.SelectedBackgroundView = new UIView(new RectangleF(0, 0, (float)cell.Bounds.Width, (float)cell.Bounds.Height))
                {
                    BackgroundColor = UIColor.Red
                };
            }
            return cell;
        }
    }
}
