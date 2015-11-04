using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.Views
{

	public class Option : ContentView
	{
		const int UnselectedImageIndex = 0;
		const int SelectedImageIndex = 1;

		public event EventHandler<EventArgs<bool>> IsSelectedChanged;

		Label Label { get; set; }
		PagePanel PagePanel { get; set; }

		public static readonly BindableProperty TextProperty = BindableProperty.Create<Option, string> (
			p => p.Text,
			"Option",
			BindingMode.OneWay,
			propertyChanged: OnTextChanged);

		public static readonly BindableProperty TextColorProperty = BindableProperty.Create<Option, Color> (
			p => p.TextColor,
			Color.Black,
			BindingMode.OneWay,
			propertyChanged: OnTextColorChanged);

		public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create<Option, string> (
			p => p.FontFamily,
			String.Empty,
			BindingMode.OneWay,
			propertyChanged: OnFontFamilyChanged);

		public static readonly BindableProperty FontSizeProperty = BindableProperty.Create<Option, double> (
			p => p.FontSize,
			-1,
			BindingMode.OneWay,
			propertyChanged: OnFontSizeChanged);

		public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create<Option, bool> (
			p => p.IsSelected,
			false,
			BindingMode.TwoWay,
			propertyChanged: OnIsSelectedChanged);

		public static readonly BindableProperty SelectedSourceProperty = BindableProperty.Create<Option, ImageSource> (
			p => p.SelectedSource,
			null,
			BindingMode.OneWay,
			propertyChanged: OnSelectedSourceChanged);

		public static readonly BindableProperty UnselectedSourceProperty = BindableProperty.Create<Option, ImageSource> (
			p => p.UnselectedSource,
			null,
			BindingMode.OneWay,
			propertyChanged: OnUnselectedSourceChanged);

		public Option ()
		{
			Label = new Label {
				Text = "Option",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.Center
			};

			PagePanel = new PagePanel {
				HorizontalOptions = LayoutOptions.End,
				Pages = new List<View> {
					new Image (),
					new Image ()
				}
			};

			var layout = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = {
					Label,
					PagePanel
				}
			};

			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += (sender, e) => OnTapped ();
			GestureRecognizers.Add (tapGestureRecognizer);

			Content = layout;

			SetImageState ();
			SetLabelState ();
		}

		public bool IsSelected {
			get { return (bool)GetValue (IsSelectedProperty); }
			set { SetValue (IsSelectedProperty, value); }
		}

		public string Text {
			get { return (string)GetValue (TextProperty); }
			set { SetValue (TextProperty, value); }
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

		protected virtual void OnTapped ()
		{
			IsSelected = true;
		}

		protected virtual void RaiseOnIsSelectedChanged ()
		{
			var handler = IsSelectedChanged;
			if (handler != null) {
				handler (this, new EventArgs<bool> (IsSelected));
			}
		}

		protected virtual void OnTextChanged (string oldValue, string newValue)
		{
			SetLabelState ();
		}

		protected virtual void OnTextColorChanged (Color oldValue, Color newValue)
		{
			SetLabelState ();
		}

		protected virtual void OnFontFamilyChanged (string oldValue, string newValue)
		{
			SetLabelState ();
		}

		protected virtual void OnFontSizeChanged (double oldValue, double newValue)
		{
			SetLabelState ();
		}

		protected virtual void OnIsSelectedChanged (bool oldValue, bool newValue)
		{			
			SetImageState ();
			RaiseOnIsSelectedChanged ();
		}

		protected virtual void OnSelectedSourceChanged (ImageSource oldValue, ImageSource newValue)
		{
			((Image)PagePanel.Pages [SelectedImageIndex]).Source = newValue;
		}

		protected virtual void OnUnselectedSourceChanged (ImageSource oldValue, ImageSource newValue)
		{
			((Image)PagePanel.Pages [UnselectedImageIndex]).Source = newValue;
		}

		protected virtual void SetImageState ()
		{
			PagePanel.SelectedPage = PagePanel.Pages [IsSelected ? SelectedImageIndex : UnselectedImageIndex];
		}

		protected virtual void SetLabelState ()
		{
			Label.Text = Text;
			Label.TextColor = TextColor;

			if (!String.IsNullOrEmpty (FontFamily)) {
				Label.FontFamily = FontFamily;
			}

			if (FontSize > 0) {
				Label.FontSize = FontSize;
			}
		}

		static void OnTextChanged (BindableObject bindable, string oldValue, string newValue)
		{
			((Option)bindable).OnTextChanged (oldValue, newValue);
		}

		static void OnTextColorChanged (BindableObject bindable, Color oldValue, Color newValue)
		{
			((Option)bindable).OnTextColorChanged (oldValue, newValue);
		}

		static void OnFontFamilyChanged (BindableObject bindable, string oldValue, string newValue)
		{
			((Option)bindable).OnFontFamilyChanged (oldValue, newValue);
		}

		static void OnFontSizeChanged (BindableObject bindable, double oldValue, double newValue)
		{
			((Option)bindable).OnFontSizeChanged (oldValue, newValue);
		}

		static void OnIsSelectedChanged (BindableObject bindable, bool oldValue, bool newValue)
		{
			((Option)bindable).OnIsSelectedChanged (oldValue, newValue);
		}

		static void OnSelectedSourceChanged (BindableObject bindable, ImageSource oldValue, ImageSource newValue)
		{
			((Option)bindable).OnSelectedSourceChanged (oldValue, newValue);
		}

		static void OnUnselectedSourceChanged (BindableObject bindable, ImageSource oldValue, ImageSource newValue)
		{
			((Option)bindable).OnUnselectedSourceChanged (oldValue, newValue);
		}
	}
	
}
