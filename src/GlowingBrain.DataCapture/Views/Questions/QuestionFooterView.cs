using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views.Questions
{
	public class QuestionFooterView : ContentView
	{
		public QuestionFooterView (SurveyItem question, SurveyPageAppearance appearance)
		{
			Content = new StackLayout {
				Style = appearance.QuestionFooterLayoutStyle,
				Children = {
					new Label {
						Text = question.Footnote,
						VerticalOptions = LayoutOptions.Start,
						Style = appearance.QuestionFooterLabelStyle
					}
				}
			};
		}
	}		
}
