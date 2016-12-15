using System;
using CoreGraphics;
using CoreAnimation;
using Foundation;
using UIKit;
using NewDataAlert;

namespace SampleApp
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			NewAlert alert = new NewAlert();
			alert.ShowMessage("New Tweets", this.View);
			alert.Process += (sender, e) => {
				this.View.BackgroundColor = UIColor.Yellow;
			};
		}
	}
}