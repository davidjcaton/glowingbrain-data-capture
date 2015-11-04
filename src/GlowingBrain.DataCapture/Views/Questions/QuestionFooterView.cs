using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views.Questions
{
	public class QuestionFooterView : ContentView
	{
		public QuestionFooterView (SurveyItem question, SurveyPageAppearance appearance)
		{
			var stackLayout = new StackLayout ();

			var footnoteLabel = new Label {
				Text = question.Footnote,
				FontSize = appearance.FooterFontSize
			};

			footnoteLabel.VerticalOptions = LayoutOptions.Start;
			stackLayout.Children.Add (footnoteLabel);

			Content = stackLayout;
		}
	}		
}
