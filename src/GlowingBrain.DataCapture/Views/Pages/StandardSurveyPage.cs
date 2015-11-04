using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views.Pages
{
	public class StandardSurveyPage : StandardSurveyPageBase
	{
		public StandardSurveyPage ()
		{
			Content = new StackLayout {
				Children = {					
					OnCreatePageItemsView (),
					OnCreateNavigationView ()
				}
			};
		}

		protected View OnCreateNavigationView ()
		{
			var backButton = new Button {
				Text = "Back",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			backButton.SetBinding (Button.CommandProperty, new Binding ("NavigateBack", BindingMode.OneWay));

			var submitButton = new Button {
				Text = "Next",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			submitButton.SetBinding (Button.CommandProperty, new Binding ("SubmitPage", BindingMode.OneWay));

			var stackLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.End,
				Orientation = StackOrientation.Horizontal,
				Children = { 
					backButton, 
					submitButton
				}
			};

			return stackLayout;
		}
	}
}
