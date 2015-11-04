using System;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views
{

	/// <summary>
	/// Abstract base class for editor views that show placeholder text before a value has
	/// been selected (either programmatically or interactively). 
	/// </summary>
	public abstract class PlaceholderView<TValue, TEditorView> : ContentView where TEditorView : View
	{
		protected readonly StackLayout StackLayout;
		protected readonly Button PlaceholderButton;
		protected readonly TEditorView EditorView;

		public static readonly BindableProperty ValueProperty = 
			BindableProperty.Create<PlaceholderView<TValue, TEditorView>, TValue> (
				p => p.Value, 
				default(TValue),
				BindingMode.TwoWay,
				propertyChanged: OnValueChanged);

		public static readonly BindableProperty PlaceholderTextProperty = 
			BindableProperty.Create<PlaceholderView<TValue, TEditorView>, string> (
				p => p.PlaceholderText, 
				default(string),
				BindingMode.TwoWay,
				propertyChanged: OnPlaceholderTextChanged);

		public static readonly BindableProperty PlaceholderTextColorProperty = 
			BindableProperty.Create<PlaceholderView<TValue, TEditorView>, Color> (
				p => p.PlaceholderTextColor, 
				Color.Gray,
				BindingMode.TwoWay,
				propertyChanged: OnPlaceholderTextColorChanged);

		protected PlaceholderView ()
		{
			this.StackLayout = new StackLayout { Orientation = StackOrientation.Horizontal };

			this.PlaceholderButton = new Button ();

			// remove border and background to make the appearance 'label-like'
			this.PlaceholderButton.BorderWidth = 0;
			this.PlaceholderButton.BackgroundColor = Color.Transparent;
			this.PlaceholderButton.Clicked += PlaceholderButton_Clicked;
			this.StackLayout.Children.Add (PlaceholderButton);

			this.EditorView = CreateEditorView ();
			this.EditorView.IsVisible = false;
			this.StackLayout.Children.Add (this.EditorView);

			this.Content = StackLayout;
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		public TValue Value {
			get { return (TValue)GetValue (ValueProperty); }
			set { SetValue (ValueProperty, value); }
		}

		/// <summary>
		/// Gets or sets the placeholder text.
		/// </summary>
		/// <value>The placeholder text.</value>
		public string PlaceholderText {
			get { return (string)GetValue (PlaceholderTextProperty); }
			set { SetValue (PlaceholderTextProperty, value); }
		}
		/// <summary>
		/// Gets or sets the color of the placeholder text.
		/// </summary>
		/// <value>The color of the placeholder text.</value>
		public Color PlaceholderTextColor {
			get { return (Color)GetValue (PlaceholderTextColorProperty); }
			set { SetValue (PlaceholderTextColorProperty, value); }
		}

		/// <summary>
		/// Subtypes should override and create a view that provides editor behavior
		/// </summary>
		/// <returns>The editor view.</returns>
		protected abstract TEditorView CreateEditorView ();

		/// <summary>
		/// Subtypes should override and implement behavior to determine if the placeholder
		/// control should be shown for the given value
		/// </summary>
		/// <returns><c>true</c>, if show placeholder was shoulded, <c>false</c> otherwise.</returns>
		/// <param name="value">Value.</param>
		protected abstract bool ShouldShowPlaceholder (TValue value);

		/// <summary>
		/// Subtypes should override and implement behavior to apply the given value to the
		/// editor view
		/// </summary>
		/// <param name="value">Value.</param>
		protected abstract void SetEditorViewValue (TValue value);

		protected virtual void OnPlaceholderTextChanged (string oldValue, string newValue)
		{
			PlaceholderButton.Text = newValue;
		}

		protected virtual void OnPlaceholderTextColorChanged (Color oldValue, Color newValue)
		{
			PlaceholderButton.TextColor = newValue;
		}

		protected virtual void OnValueChanged (TValue oldValue, TValue newValue)
		{
			var isPlaceholderVisible = ShouldShowPlaceholder (newValue);

			if (isPlaceholderVisible) {		
				// hide date picker and show placeholder
				if (this.EditorView.IsVisible) {
					this.EditorView.IsVisible = false;
					this.PlaceholderButton.IsVisible = true;
				}
			} else {
				// hide place holder and show date picker
				if (this.PlaceholderButton.IsVisible) {
					this.PlaceholderButton.IsVisible = false;
					this.EditorView.IsVisible = true;
				}
				SetEditorViewValue (newValue);
			}
		}

		protected virtual void PlaceholderButton_Clicked (object sender, EventArgs e)
		{
			// hide placeholder, show date picker and activate by giving focus
			this.PlaceholderButton.IsVisible = false;
			this.EditorView.IsVisible = true;
			ActivateEditorView ();
		}

		protected virtual void ActivateEditorView ()
		{
			this.EditorView.Focus ();
		}

		static void OnPlaceholderTextChanged (BindableObject bindable, string oldValue, string newValue)
		{
			var control = bindable as PlaceholderView<TValue, TEditorView>;
			control.OnPlaceholderTextChanged (oldValue, newValue);
		}

		static void OnPlaceholderTextColorChanged (BindableObject bindable, Color oldValue, Color newValue)
		{
			var control = bindable as PlaceholderView<TValue, TEditorView>;
			control.OnPlaceholderTextColorChanged (oldValue, newValue);
		}

		static void OnValueChanged (BindableObject bindable, TValue oldValue, TValue newValue)
		{
			var control = bindable as PlaceholderView<TValue, TEditorView>;
			control.OnValueChanged (oldValue, newValue);
		}
	}	
	
}
