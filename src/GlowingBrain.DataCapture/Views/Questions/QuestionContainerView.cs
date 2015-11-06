using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views.Questions
{

	public class QuestionContainerView : ContentView
	{
		public QuestionContainerView (ISurveyItem item, View questionView, SurveyPageAppearance appearance)
		{
			var headerView = new QuestionHeaderView (item, appearance) {
				VerticalOptions = LayoutOptions.Start
			};

			var inputStackLayout = new StackLayout () {
				Style = appearance.QuestionContainerLayoutStyle,
				Children = {
					StandardViews.CreateSeparator (appearance.SeperatorStyle),
					questionView,
					StandardViews.CreateSeparator (appearance.SeperatorStyle)
				}
			};

			var stackLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {
					headerView,
					inputStackLayout,
				}
			};

			if (!String.IsNullOrWhiteSpace (item.Footnote)) {
				var footerView = new QuestionFooterView (item, appearance);
				stackLayout.Children.Add (footerView);
			}

			Content = stackLayout;
		}
	}
}
