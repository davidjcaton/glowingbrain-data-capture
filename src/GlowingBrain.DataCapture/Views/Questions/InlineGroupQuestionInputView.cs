using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.Views.Questions
{

	public class InlineGroupQuestionInputView : QuestionInputView
	{
		public InlineGroupQuestionInputView (InlineGroupQuestion question, SurveyPageAppearance appearance)
			: base (appearance)
		{
			var childQuestionListView = new ChildQuestionList (appearance);
			childQuestionListView.HorizontalOptions = LayoutOptions.FillAndExpand;
			childQuestionListView.VerticalOptions = LayoutOptions.Fill;

			var childQuestionViews = new List<View> ();
			foreach (var childQuestion in question.Children) {
				var childQuestionView = SurveyItemViewFactory.Default.CreateViewForItem (childQuestion, appearance, false);
				childQuestionViews.Add (childQuestionView);
			}

			childQuestionListView.Items = childQuestionViews;

			HeightRequest = -1;
			Content = childQuestionListView;
		}

		class ChildQuestionList : SimpleListView
		{
			readonly SurveyPageAppearance _appearance;

			public ChildQuestionList (SurveyPageAppearance appearance)
			{
				_appearance = appearance;	
			}

			protected override View OnCreateSeperatorView ()
			{
				return StandardViews.CreateSeparator (_appearance.ItemSeperatorStyle);
			}
		}
	}
	
}
