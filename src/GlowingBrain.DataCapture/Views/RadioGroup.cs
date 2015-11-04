using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace GlowingBrain.DataCapture.Views
{

	public class RadioGroup : StackLayout
	{
		readonly Dictionary<Option, object> _optionToItemMap = new Dictionary<Option, object> ();

		public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create<RadioGroup, object> (
			p => p.SelectedItem,
			null,
			BindingMode.TwoWay,
			propertyChanged: OnSelectedItemChanged);

		public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create<RadioGroup, IEnumerable> (
			p => p.ItemsSource,
			null,
			BindingMode.OneWay,
			propertyChanged: OnItemsSourceChanged);

		public static readonly BindableProperty TextColorProperty = BindableProperty.Create<RadioGroup, Color> (
			p => p.TextColor,
			Color.Black,
			BindingMode.OneWay);

		public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create<RadioGroup, string> (
			p => p.FontFamily,
			String.Empty,
			BindingMode.OneWay);

		public static readonly BindableProperty FontSizeProperty = BindableProperty.Create<RadioGroup, double> (
			p => p.FontSize,
			-1,
			BindingMode.OneWay);

		public static readonly BindableProperty SelectedSourceProperty = BindableProperty.Create<RadioGroup, ImageSource> (
			p => p.SelectedSource,
			null,
			BindingMode.OneWay);

		public static readonly BindableProperty UnselectedSourceProperty = BindableProperty.Create<RadioGroup, ImageSource> (
			p => p.UnselectedSource,
			null,
			BindingMode.OneWay);

		public RadioGroup ()
		{			
		}

		public object SelectedItem {
			get { return GetValue (SelectedItemProperty); }
			set { SetValue (SelectedItemProperty, value); }
		}

		public IEnumerable ItemsSource {
			get { return (IEnumerable)GetValue (ItemsSourceProperty); }
			set { SetValue (ItemsSourceProperty, value); }
		}

		public Color TextColor {
			get { return (Color)GetValue (TextColorProperty); }
			set { SetValue (TextColorProperty, value); }
		}

		public string FontFamily {
			get { return (string)GetValue (FontFamilyProperty); }
			set { SetValue (FontFamilyProperty, value); }
		}

		public double FontSize {
			get { return (double)GetValue (FontSizeProperty); }
			set { SetValue (FontSizeProperty, value); }
		}

		public ImageSource SelectedSource {
			get { return (ImageSource)GetValue (SelectedSourceProperty); }
			set { SetValue (SelectedSourceProperty, value); }
		}

		public ImageSource UnselectedSource {
			get { return (ImageSource)GetValue (UnselectedSourceProperty); }
			set { SetValue (UnselectedSourceProperty, value); }
		}

		protected virtual void OnSelectedItemChanged (object oldValue, object newValue)
		{
			foreach (var kv in _optionToItemMap) {
				var isOptionForItem = Object.Equals (newValue, kv.Value);
				kv.Key.IsSelected = isOptionForItem;
			}
		}

		protected virtual void OnItemsSourceChanged (IEnumerable oldValue, IEnumerable newValue)
		{
			PopulateOptions ();
		}

		protected virtual void PopulateOptions ()
		{
			// remove existing child options
			foreach (var existingOption in Children.OfType<Option> ()) {
				existingOption.IsSelectedChanged -= Option_IsSelectedChanged;
			}

			Children.Clear ();
			_optionToItemMap.Clear ();

			// add new and add event handler
			var items = ItemsSource;
			if (items != null) {
				var itemList = items.ToList ();
				for (var i = 0; i < itemList.Count; i++) {
					var item = itemList [i];
					if (item != null) {
						//var isFirst = (i == 0);
						var isLast = (i == itemList.Count - 1);

						var option = CreateOptionForItem (item);
						option.IsSelectedChanged += Option_IsSelectedChanged;
						Children.Add (option);
						_optionToItemMap.Add (option, item);

						if (!isLast) {
							var separator = CreateSeperatorView ();
							if (separator != null) {
								Children.Add (separator);
							}
						}
					}
				}
			}
		}

		protected virtual View CreateSeperatorView ()
		{
			return null;
		}

		protected virtual Option CreateOptionForItem (object item)
		{
			var option = new Option (); 
			InitializeOption (option, item);

			return option;
		}

		protected virtual void InitializeOption (Option option, object item)
		{
			var text = item.ToString ();

			option.Text = text;
			option.TextColor = TextColor; 
			option.FontSize = FontSize; 
			option.FontFamily = FontFamily; 
			option.SelectedSource = SelectedSource; 
			option.UnselectedSource = UnselectedSource; 
			option.HorizontalOptions = LayoutOptions.FillAndExpand;
		}

		protected virtual void Option_IsSelectedChanged (object sender, EventArgs<bool> e)
		{			
			if (e.Value) {
				var selectedOption = (Option)sender;
				var item = _optionToItemMap [selectedOption];
				SelectedItem = item;
			}
		}

		static void OnSelectedItemChanged (BindableObject bindable, object oldValue, object newValue)
		{
			((RadioGroup)bindable).OnSelectedItemChanged (oldValue, newValue);
		}

		static void OnItemsSourceChanged (BindableObject bindable, IEnumerable oldValue, IEnumerable newValue)
		{
			((RadioGroup)bindable).OnItemsSourceChanged (oldValue, newValue);
		}
	}
	
}
