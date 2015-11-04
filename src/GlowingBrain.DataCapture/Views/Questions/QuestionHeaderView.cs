using System;
using Xamarin.Forms;
using GlowingBrain.DataCapture.ViewModels;

namespace GlowingBrain.DataCapture.Views.Questions
{
	public class QuestionHeaderView : ContentView
	{
		public QuestionHeaderView (SurveyItem question, SurveyPageAppearance appearance)
		{
			Content = new StackLayout {
				Style = appearance.QuestionHeaderLayoutStyle,
				Children = {
					new Label {
						Text = question.Caption,
						VerticalOptions = LayoutOptions.FillAndExpand,
						Style = appearance.QuestionHeaderLabelStyle
					}
				}
			};
		}
	}		
}
