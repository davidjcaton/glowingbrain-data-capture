using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace GlowingBrain.DataCapture.Views
{

	public class PagePanel : ContentView
	{
		Grid Grid { get; set; }

		public static readonly BindableProperty PagesProperty = BindableProperty.Create<PagePanel, IList<View>> (
			p => p.Pages,
			default (IList<View>),
			BindingMode.OneWay,
			propertyChanged: OnPagesChanged);

		public static readonly BindableProperty SelectedPageProperty = BindableProperty.Create<PagePanel, View> (
			p => p.SelectedPage,
			default (View),
			BindingMode.TwoWay,
			propertyChanged: OnSelectedPageChanged);

		public PagePanel ()
		{
			Grid = new Grid ();
			Grid.RowDefinitions.Add (new RowDefinition ());
			Grid.ColumnDefinitions.Add (new ColumnDefinition ());

			Content = Grid;
		}

		public IList<View> Pages {
			get { return (IList<View>) GetValue (PagesProperty); }
			set { SetValue (PagesProperty, value); }
		}

		public View SelectedPage {
			get { return (View) GetValue (SelectedPageProperty); }
			set { SetValue (SelectedPageProperty, value); }
		}

		protected virtual void OnPagesChanged (IList<View> oldValue, IList<View> newValue)
		{
			Grid.Children.Clear ();

			if (newValue != null) {
				if (newValue.Any ()) {
					foreach (var view in newValue) {
						Grid.Children.Add (view);
						view.Opacity = 0.0;
					}
					SelectedPage = newValue.First ();
				}
			}
		}

		protected virtual void OnSelectedPageChanged (View oldValue, View newValue)
		{
			if (newValue != null) {
				if (oldValue != null) {
					// fade to target
					this.Animate ("fade", percent => {
						oldValue.Opacity = 1.0 - percent;
						newValue.Opacity = percent;
					});
				} else {
					// show immediately
					newValue.Opacity = 1.0;
				}
			}
		}

		static void OnPagesChanged (BindableObject bindable, IList<View> oldValue, IList<View> newValue)
		{
			((PagePanel)bindable).OnPagesChanged (oldValue, newValue);
		}

		static void OnSelectedPageChanged (BindableObject bindable, View oldValue, View newValue)
		{
			((PagePanel)bindable).OnSelectedPageChanged (oldValue, newValue);
		}
	}
	
}
