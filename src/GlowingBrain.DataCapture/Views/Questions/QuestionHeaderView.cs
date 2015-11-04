using System;
using Xamarin.Forms;
using GlowingBrain.DataCapture.ViewModels;

namespace GlowingBrain.DataCapture.Views.Questions
{
	public class QuestionHeaderView : ContentView
	{
		public QuestionHeaderView (SurveyItem question, SurveyPageAppearance settings)
		{
			var stackLayout = new StackLayout ();

			var captionLabel = new Label {
				Text = question.Caption,
				FontAttributes = FontAttributes.Bold,
				VerticalOptions = LayoutOptions.FillAndExpand,
				YAlign = TextAlignment.End
			};

			stackLayout.Children.Add (captionLabel);
			stackLayout.HeightRequest = settings.HeaderHeight;

			Content = stackLayout;
		}
	}		
}
