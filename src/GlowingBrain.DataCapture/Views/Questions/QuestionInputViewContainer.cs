using System;
using Xamarin.Forms;
using GlowingBrain.DataCapture.ViewModels;

namespace GlowingBrain.DataCapture.Views.Questions
{
	public class QuestionInputViewContainer : ContentView
	{
		public QuestionInputViewContainer (IQuestion question, View view, SurveyPageAppearance appearance)
		{
			view.HorizontalOptions = LayoutOptions.FillAndExpand;

			var errorLabel = new Label { 
				Style = appearance.QuestionErrorLabelStyle,
				Text = String.Empty, 
				IsVisible = false,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			question.PropertyChanged += (sender, e) => {
				if (e.PropertyName == "HasError") {
					if (question.HasError) {
						errorLabel.Text = question.ErrorMessage;
						errorLabel.IsVisible = true;
					} else {
						errorLabel.IsVisible = false;
					}
				}
			};

			Content = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Style = appearance.QuestionInputViewContainerLayoutStyle,
				Children = {
					view,
					errorLabel
				}
			};
		}
	}
}
