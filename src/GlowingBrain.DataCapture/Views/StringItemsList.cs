using System;
using System.Collections;
using GlowingBrain.DataCapture.Infrastructure;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views
{
	public class StringItemsList : StackLayout
	{
		public StringItemsList ()
		{
			Orientation = StackOrientation.Horizontal;
		}

		public static BindableProperty ItemsProperty = BindableProperty.Create<StringItemsList, IEnumerable>(
			p => p.Items,
			null,
			BindingMode.OneWay,
			propertyChanged: OnItemsChanged);
		
		public IEnumerable Items { 
			get { return (IEnumerable)GetValue (ItemsProperty); }
			set { SetValue (ItemsProperty, value); }
		}

		public Style LabelStyle { get; set; }

		protected virtual void OnItemsChanged (IEnumerable oldValue, IEnumerable newValue)
		{
			Children.Clear ();

			if (newValue != null) {
				var list = newValue.ToList ();
				for (var i = 0; i < list.Count; i++) {
					var listPosition = list.GetListPosition (i);
					var label = OnCreateLabelForItem (list [i], listPosition);
					Children.Add (label);
				}
			}
		}

		protected virtual Label OnCreateLabelForItem (object item, ListPosition listPosition)
		{
			var text = (item != null) ? item.ToString () : String.Empty;
			var label = new Label { Text = text };
			if (Orientation == StackOrientation.Horizontal) {
				label.HorizontalOptions = listPosition.GetLayoutOption ();
				label.VerticalOptions = LayoutOptions.Center;
			} else {
				label.HorizontalOptions = LayoutOptions.Center;
				label.VerticalOptions = listPosition.GetLayoutOption ();
			}

			if (LabelStyle != null) {
				label.Style = LabelStyle;
			}

			return label;
		}

		static void OnItemsChanged (BindableObject bindable, IEnumerable oldValue, IEnumerable newValue)
		{
			((StringItemsList)bindable).OnItemsChanged (oldValue, newValue);
		}
	}
	
}
