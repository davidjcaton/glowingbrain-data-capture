using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.Views
{
	public class BusyIndicator : ContentView
	{
		StatefulContentView<bool> StatefulContent { get; set; }
		ActivityIndicator ActivityIndicator { get; set; }

		public static readonly BindableProperty ContentProperty = BindableProperty.Create<BusyIndicator, View> (
			p => p.Content,
			default(View),
			BindingMode.TwoWay,
			propertyChanged: OnContentPropertyChanged);

		public static readonly BindableProperty IsBusyProperty = BindableProperty.Create<BusyIndicator, bool> (
			p => p.IsBusy,
			false,
			BindingMode.TwoWay,
			propertyChanged: OnIsBusyPropertyChanged);

		public BusyIndicator ()
		{
			this.ActivityIndicator = new ActivityIndicator ();
			this.StatefulContent = new StatefulContentView<bool> ();
			SetItems ();
			SetState ();

			base.Content = this.StatefulContent;
		}

		public new View Content {
			get { return (View)GetValue (ContentProperty); }
			set { SetValue (ContentProperty, value); }
		}

		public bool IsBusy {
			get { return (bool)GetValue (IsBusyProperty); }
			set { SetValue (IsBusyProperty, value); }
		}

		protected void OnContentPropertyChanged (View oldValue, View newValue)
		{
			SetItems ();
			SetState ();
		}

		protected void OnIsBusyPropertyChanged (bool oldValue, bool newValue)
		{
			SetState ();
		}

		void SetItems ()
		{
			this.StatefulContent.StateContentItems = new List<StateContent<bool>> {
				new StateContent<bool> {
					State = true,
					Content = this.ActivityIndicator
				},
				new StateContent<bool> {
					State = false,
					Content = this.Content
				}
			};
		}

		void SetState ()
		{
			this.StatefulContent.CurrentState = this.IsBusy;
			this.ActivityIndicator.IsRunning = this.IsBusy;
		}

		static void OnContentPropertyChanged (BindableObject bindable, View oldValue, View newValue)
		{
			((BusyIndicator)bindable).OnContentPropertyChanged (oldValue, newValue);
		}

		static void OnIsBusyPropertyChanged (BindableObject bindable, bool oldValue, bool newValue)
		{
			((BusyIndicator)bindable).OnIsBusyPropertyChanged (oldValue, newValue);
		}
	}
	
}
