using System;

using UIKit;
using GalaSoft.MvvmLight.Helpers;
using HelloXamarin.Core.ViewModel;

namespace MVVMLightBinding
{
	public partial class ViewController : UIViewController
	{
		private Binding<string, string> _textLabelBinding;
		private Binding _textFieldBinding;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		private MainViewModel Vm {
			get {
				return Application.Locator.Main;
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			HideKeyboardHandling ();

			_textLabelBinding = this.SetBinding (
				() => Vm.PreviousMessage,
				() => TextLabel.Text);

			EntryTextField.EditingDidEnd += (sender, e) => {};
			_textFieldBinding = this.SetBinding (
				() => EntryTextField.Text)
				.UpdateSourceTrigger ("EditingDidEnd")
				.WhenSourceChanges (() => Vm.Message = EntryTextField.Text);

			SubmitTextButton.TouchUpInside += (sender, e) => {};
			SubmitTextButton.SetCommand("TouchUpInside", Vm.MessageCommand);
		}


		void HideKeyboardHandling ()
		{
			EntryTextField.ShouldReturn = textField => {
				textField.ResignFirstResponder ();
				return true;
			};
			var g = new UITapGestureRecognizer (() => View.EndEditing (true));
			g.CancelsTouchesInView = false;
			//for iOS5
			View.AddGestureRecognizer (g);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.

		}
	}
}

