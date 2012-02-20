using System;
using MonoMac.AppKit;
using Eto.Forms;
using Eto.Drawing;
using Eto.Platform.Mac.Drawing;

namespace Eto.Platform.Mac.Forms.Controls
{
	public class ImageCellHandler : CellHandler<NSImageCell, ImageCell>, IImageCell
	{
		public ImageCellHandler ()
		{
			Control = new NSImageCell();
		}
		
		public override MonoMac.Foundation.NSObject GetObjectValue (object val)
		{
			var img = val as Image;
			if (img != null) {
				var imgHandler = ((IImageSource)img.Handler);
				return imgHandler.GetImage ();
			}
			return null;
		}

		public override object SetObjectValue (MonoMac.Foundation.NSObject val)
		{
			return null;
		}
		
		public override float GetPreferredSize (object value, System.Drawing.SizeF cellSize)
		{
			var img = value as Image;
			if (img != null) {
				return cellSize.Height / (float)img.Size.Height * (float)img.Size.Width;
			}
			return 16;
		}
	}
}
