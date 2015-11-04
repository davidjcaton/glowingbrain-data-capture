using System;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views
{

	/// <summary>
	/// Implementation of a date entry control based on the <see cref="DatePicker"/> view 
	/// but additionally allowing data binding to nullable <see cref="DateTime"/> values
	/// and provision of placeholder text to display when the value is null
	/// </summary>
	public class ExtendedDatePicker : PlaceholderView<DateTime?, DatePicker>
	{
		public static readonly BindableProperty FormatProperty = 
			BindableProperty.Create<ExtendedDatePicker, string> (
				p => p.Format, 
				"yyyy-MM-dd",
				BindingMode.TwoWay,
				propertyChanged: OnFormatChanged);

		protected GBDatePicker DatePicker;

		/// <summary>
		/// Gets or sets the date format.
		/// </summary>
		/// <value>The format.</value>
		public string Format {
			get { return (string)GetValue (FormatProperty); }
			set { SetValue (FormatProperty, value); }
		}

		protected override DatePicker CreateEditorView ()
		{
			this.DatePicker = new GBDatePicker ();
			this.DatePicker.DateSelected += DatePicker_DateSelected;
			return DatePicker;
		}

		protected override void SetEditorViewValue (DateTime? value)
		{
			if (value.HasValue) {
				DatePicker.Date = value.Value;
			}
		}

		protected override bool ShouldShowPlaceholder (DateTime? value)
		{
			return !value.HasValue;
		}

		protected override void ActivateEditorView ()
		{
			// default to today's date
			if (!this.Value.HasValue) {
				this.Value = DateTime.Today;
			}

			base.ActivateEditorView ();
		}

		protected virtual void OnFormatChanged (string oldValue, string newValue)
		{
			this.DatePicker.Format = newValue;
		}

		static void OnFormatChanged (BindableObject bindable, string oldValue, string newValue)
		{
			var control = bindable as ExtendedDatePicker;
			control.OnFormatChanged (oldValue, newValue);
		}

		void DatePicker_DateSelected (object sender, DateChangedEventArgs e)
		{
			// sync bindable property to control change
			this.Value = e.NewDate;
		}
	}	
	
}
