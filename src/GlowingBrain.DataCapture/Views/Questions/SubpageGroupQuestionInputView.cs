using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views.Questions
{
	public class SubpageGroupQuestionInputView : QuestionInputView
	{
		readonly SubpageGroupQuestion _question;

		public SubpageGroupQuestionInputView (SubpageGroupQuestion question, SurveyPageAppearance appearance)
			: base (appearance)
		{
			_question = question;

			var stackLayout = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			var captionLabel = new Label {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Text = question.SummaryText
			};

			question.PropertyChanged += (sender, e) => {
				if (e.PropertyName == "SummaryText") {
					captionLabel.Text = question.SummaryText;
				}
			};

			stackLayout.Children.Add (captionLabel);

			var disclosureImage = new Image {
				Source = appearance.DisclosureImageSource,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			stackLayout.Children.Add (disclosureImage);

			Content = stackLayout;

			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += (sender, e) => OnTapped ();
			GestureRecognizers.Add (tapGestureRecognizer);
		}

		protected SubpageGroupQuestion Question {
			get { return _question; }
		}

		protected virtual void OnTapped ()
		{
			var subpage = OnCreateSubpage (Question);
			if (subpage != null) {
				OnShowSubpage (subpage);	
			}
		}

		protected virtual Page OnCreateSubpage (SubpageGroupQuestion question)
		{
			var page = QuestionViews.PageForContainerQuestion (question, Appearance);
			return page;
		}

		protected virtual void OnShowSubpage (Page subpage)
		{
			Navigation.PushAsync (subpage);
		}
	}
	
}
