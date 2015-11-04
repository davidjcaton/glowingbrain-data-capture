using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.Views
{
	public class SimpleListView : StackLayout
	{
		public static readonly BindableProperty ItemsProperty = BindableProperty.Create<SimpleListView, IList<View>> (
			p => p.Items,
			new List<View> (),
			BindingMode.OneWay,
			propertyChanged: OnItemsChanged);

		public IList<View> Items {
			get { return (IList<View>)GetValue (ItemsProperty); }
			set { SetValue (ItemsProperty, value); }
		}

		protected virtual void OnItemsChanged (IList<View> oldValue, IList<View> newValue)
		{
			Children.Clear ();

			if (newValue == null) {
				return;
			}

			for (var i = 0; i < newValue.Count; i++) {
				var isLastItem = (i == newValue.Count - 1);
				Children.Add (newValue [i]);
				if (!isLastItem) {
					var separator = OnCreateSeperatorView ();
					if (separator != null) {
						Children.Add (separator);
					}
				}
			}
		}

		protected virtual View OnCreateSeperatorView ()
		{
			return null;
		}

		static void OnItemsChanged (BindableObject bindable, IList<View> oldValue, IList<View> newValue)
		{
			((SimpleListView)bindable).OnItemsChanged (oldValue, newValue);
		}
	}
	
}
