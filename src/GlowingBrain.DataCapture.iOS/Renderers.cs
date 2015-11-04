using System;
using GlowingBrain.DataCapture.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GBDatePicker), typeof(GlowingBrain.DataCapture.iOS.GBDatePickerRenderer))]
[assembly: ExportRenderer(typeof(GBPicker), typeof(GlowingBrain.DataCapture.iOS.GBPickerRenderer))]
[assembly: ExportRenderer(typeof(GBEntry), typeof(GlowingBrain.DataCapture.iOS.GBEntryRenderer))]

namespace GlowingBrain.DataCapture.iOS
{
	public class GBDatePickerRenderer : DatePickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged(e);
			Control.BorderStyle = UITextBorderStyle.None;
		}
	}

	public class GBPickerRenderer : PickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);
			Control.BorderStyle = UITextBorderStyle.None;
		}
	}

	public class GBEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			Control.BorderStyle = UITextBorderStyle.None;
		}
	}
}

