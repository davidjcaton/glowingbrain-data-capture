using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.Views
{

	/// <summary>
	/// Implements a picker control based on the <see cref="Picker"/> view but additionally
	/// allowing picker items set via data binding and placeholder text to be specified 
	/// when no item has been selected
	/// </summary>
	public abstract class ExtendedPicker<TValue> : PlaceholderView<TValue, Picker>
	{
		protected GBPicker Picker;

		public static readonly BindableProperty ItemsSourceProperty = 
			BindableProperty.Create<ExtendedPicker<TValue>, IList<TValue>> (
				p => p.ItemsSource, 
				default(IList<TValue>),
				BindingMode.OneWay,
				propertyChanged: OnItemsSourceChanged);

		/// <summary>
		/// Gets or sets the items source.
		/// </summary>
		/// <value>The items source.</value>
		public IList<TValue> ItemsSource {
			get { return (IList<TValue>)GetValue (ItemsSourceProperty); }
			set { SetValue (ItemsSourceProperty, value); }
		}

		protected override Picker CreateEditorView ()
		{
			Picker = new ResizingPicker ();
			Picker.HorizontalOptions = LayoutOptions.FillAndExpand;
			Picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
			return Picker;
		}

		protected override void SetEditorViewValue (TValue value)
		{
			SetSelectedIndex (value);
		}

		protected virtual void OnItemsSourceChanged (IList<TValue> oldValue, IList<TValue> newValue)
		{
			Picker.Items.Clear ();

			if (newValue != null) {
				foreach (var item in newValue) {
					Picker.Items.Add (item.ToString ());
				}
			}

			SetSelectedIndex (this.Value);
		}

		protected void SetSelectedIndex (TValue value)
		{
			if (this.ItemsSource == null) {
				return;
			}

			var index = 0;
			foreach (var item in this.ItemsSource) {
				if (EqualityComparer<TValue>.Default.Equals (item, value)) {
					Picker.SelectedIndex = index;
					break;
				}
				index++;
			}
		}

		void Picker_SelectedIndexChanged (object sender, EventArgs e)
		{
			if (this.ItemsSource != null) {
				var index = Picker.SelectedIndex;
				if (index >= 0 && index < this.ItemsSource.Count) {
					this.Value = this.ItemsSource [index];				
				}
			}
		}

		static void OnItemsSourceChanged (BindableObject bindable, IList<TValue> oldValue, IList<TValue> newValue)
		{
			var control = bindable as ExtendedPicker<TValue>;
			control.OnItemsSourceChanged (oldValue, newValue);
		}

		// Standard picker does not resize itself when selected item changes!
		// https://forums.xamarin.com/discussion/24712/width-of-a-picker
		class ResizingPicker : GBPicker
		{
			protected override void OnPropertyChanged (string propertyName = null)
			{
				base.OnPropertyChanged (propertyName);

				if (propertyName == GBPicker.SelectedIndexProperty.PropertyName) {
					this.InvalidateMeasure ();
				}
			}
		}
	}
	
}
