using System;
using UIKit;
using CoreGraphics;
using Foundation;

namespace NewDataAlert
{
	public class NewAlert
	{
		private bool isUpdatedAddedInWindow;
		private UIButton updateBtn;
		private bool isUpdateVisible;
		private bool hideOnTouch;
		private double showAnimationInterval;
		private double hideAnimationInterval;
		private float heightOffset;
		private UIColor backgroundColor;
		private UIColor textColor;
		private UIFont textFont;
		private float height;
		private float borderWidth;
		private UIColor borderColor;
		public event EventHandler Process;

		public NewAlert()
		{
			isUpdatedAddedInWindow = false;
			textFont = UIFont.SystemFontOfSize(12.5f);
			height = 30f;
			isUpdateVisible = false;
			hideOnTouch = true;
			showAnimationInterval = 1.0;
			hideAnimationInterval = 0.7;
			heightOffset = 78.0f;
			backgroundColor = UIColor.FromRGBA(0f, 153 / 255f, 229 / 255f, 1f);
			textColor = UIColor.White;
			borderWidth = 0.0f;
			borderColor = UIColor.DarkGray;
		}

		public void ShowMessage(string message, UIView view)
		{
			if (!isUpdatedAddedInWindow) {

				nfloat width = message.Length;
				if (width <= view.Frame.Width) {
					width = view.Frame.Width - 10.0f;
				}
				updateBtn = new UIButton(new CGRect(0, -50, 100, height));
				updateBtn.SetTitle(message, UIControlState.Normal);
				var frame = updateBtn.Frame;
				frame.X = (view.Frame.Width / 2f) - 50;
				updateBtn.Frame = frame;
				updateBtn.BackgroundColor = backgroundColor;
				updateBtn.Layer.CornerRadius = height / 2.0f;
				updateBtn.Layer.MasksToBounds = true;
				updateBtn.TitleLabel.TextAlignment = UITextAlignment.Center;
				updateBtn.SetTitleColor(textColor, UIControlState.Normal);
				updateBtn.TitleLabel.Font = textFont;
				updateBtn.Layer.BorderWidth = borderWidth;
				updateBtn.Layer.BorderColor = borderColor?.CGColor;

				updateBtn.AddTarget(UpdateButtonTouchUpInside, UIControlEvent.TouchUpInside);
				view.AddSubview(updateBtn);
				isUpdatedAddedInWindow = true;
			}

			if (!isUpdateVisible) {
				isUpdateVisible = true;
				UIView.AnimateNotify(showAnimationInterval, 0f, 0.5f, 0.5f, UIViewAnimationOptions.CurveEaseIn, () => {
					var frame = updateBtn.Frame;
					frame.Y = this.heightOffset;
					updateBtn.Frame = frame;
				}, (finished) => { });
			}
		}

		void UpdateButtonTouchUpInside(object sender, EventArgs e)
		{
			UIView.Animate(0.1f, () => {
				this.updateBtn.Transform = CGAffineTransform.MakeScale(1.0f, 1.0f);
			});

			if (this.hideOnTouch) {
				if (Process != null) {
					Process(this, new EventArgs());
				}
				HideUpdate();
			}
		}

		void HideUpdate()
		{
			isUpdateVisible = false;
			isUpdatedAddedInWindow = false;
			UIView.AnimateNotify(hideAnimationInterval, 0.4f, 0.5f, 0.8f, UIViewAnimationOptions.CurveEaseInOut, () => {
				var frame = this.updateBtn.Frame;
				frame.Y = -50;
				this.updateBtn.Frame = frame;
			}, (finished) => {
				updateBtn.RemoveFromSuperview();
			});
		}
	}
}
