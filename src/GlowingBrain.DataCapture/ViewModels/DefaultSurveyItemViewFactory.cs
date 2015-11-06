using System;
using Xamarin.Forms;
using GlowingBrain.DataCapture.Views.Questions;
using GlowingBrain.DataCapture.Views.StaticItems;
using GlowingBrain.DataCapture.Views.Pages;

namespace GlowingBrain.DataCapture.ViewModels
{

	public class DefaultSurveyItemViewFactory : ISurveyItemViewFactory
	{
		public virtual View CreateViewForItem (ISurveyItem item, SurveyPageAppearance appearance, bool wrapInContainer)
		{
			View view = null;

			if (item is DateQuestion) {
				view = new DateQuestionInputView ((DateQuestion)item, appearance);
			} else if (item is PickerOptionQuestion) {
				view = new PickerOptionQuestionInputView ((OptionQuestion)item, appearance);
			} else if (item is RadioOptionQuestion) {
				view = new RadioGroupOptionQuestionInputView ((OptionQuestion)item, appearance);
			} else if (item is NumericEntryQuantityQuestion) {
				view = new NumericEntryQuantityQuestionInputView ((QuantityQuestion)item, appearance);
			} else if (item is CheckboxBooleanQuestion) {
				view = new CheckboxBooleanQuestionInputView ((BooleanQuestion)item, appearance);
			} else if (item is InlineGroupQuestion) {
				view = new InlineGroupQuestionInputView ((InlineGroupQuestion)item, appearance);
			} else if (item is SubpageGroupQuestion) {
				view = new SubpageGroupQuestionInputView ((SubpageGroupQuestion)item, appearance);
			} else if (item is FreeTextQuestion) {
				view = new FreeTextQuestionInputView ((FreeTextQuestion)item, appearance);
			} else if (item is SliderQuantityQuestion) {
				view = new SliderQuantityQuestionInputView ((SliderQuantityQuestion)item, appearance);
			} else if (item is PageHeader) {
				view = new PageHeaderView ((PageHeader)item, appearance);
			}

			var question = item as IQuestion;
			if (question != null) {
				view = new QuestionInputViewContainer (question, view, appearance);
			}

			if (view != null && wrapInContainer) {
				view = new QuestionContainerView (item, view, appearance);
			}

			return view;
		}

		public virtual Page CreatePageForItem (ISurveyItem item, SurveyPageAppearance appearance)
		{
			Page page = null;

			if (item is ISurveySubpage) {
				page = new StandardSurveySubpage ();
			} else if (item is ISurveyPage) {
				page = new StandardSurveyPage ();
			}

			if (page != null) {
				page.BindingContext = item;
			}

			return page;
		}
	}
}
