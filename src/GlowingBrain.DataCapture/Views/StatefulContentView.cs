using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.Views
{
	[ContentProperty ("StateContentItems")]
	public class StatefulContentView<TState> : ContentView
	{
		public static readonly BindableProperty CurrentStateProperty = BindableProperty.Create<StatefulContentView<TState>, TState> (
			p => p.CurrentState,
			default(TState),
			BindingMode.TwoWay,
			propertyChanged: OnCurrentStateChanged);

		public static readonly BindableProperty StateContentItemsProperty = BindableProperty.Create<StatefulContentView<TState>, IList<StateContent<TState>>> (
			p => p.StateContentItems,
			new List<StateContent<TState>> (),
			BindingMode.OneWay,
			propertyChanged: OnStateContentItemsChanged);

		public TState CurrentState {
			get { return (TState)GetValue (CurrentStateProperty); }
			set { SetValue (CurrentStateProperty, value); }
		}

		public IList<StateContent<TState>> StateContentItems
		{
			get { return (IList<StateContent<TState>>)GetValue (StateContentItemsProperty); }
			set { SetValue (StateContentItemsProperty, value); }
		}

		protected void OnCurrentStateChanged (TState oldValue, TState newValue)
		{
			if (newValue != null) {
				TransistionToState (newValue);
			}
		}

		protected void OnStateContentItemsChanged (IList<StateContent<TState>> oldValue, IList<StateContent<TState>> newValue)
		{
			if (newValue != null) {
				TransistionToState (this.CurrentState);
			}
		}

		protected void TransistionToState (TState state)
		{			
			var stateContent = FindContentState (state);
			if (stateContent != null) {
				TransistionToView (stateContent.Content);
			}
		}

		protected StateContent<TState> FindContentState (TState state)
		{
			StateContent<TState> result = null;
			var items = this.StateContentItems;
			if (items != null) {
				foreach (var item in items) {
					if (EqualityComparer<TState>.Default.Equals (state, item.State)) {
						result = item;
					}
				}
			}

			return result;
		}

		protected void TransistionToView (View newView)
		{
			this.Content = newView;
		}

		static void OnCurrentStateChanged (BindableObject bindable, TState oldValue, TState newValue)
		{
			((StatefulContentView<TState>)bindable).OnCurrentStateChanged (oldValue, newValue);
		}

		static void OnStateContentItemsChanged (BindableObject bindable, IList<StateContent<TState>> oldValue, IList<StateContent<TState>> newValue)
		{
			((StatefulContentView<TState>)bindable).OnStateContentItemsChanged (oldValue, newValue);
		}
	}
	
}
