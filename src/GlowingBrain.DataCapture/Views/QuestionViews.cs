using System;
using GlowingBrain.DataCapture.ViewModels;
using GlowingBrain.DataCapture.Views.Pages;
using GlowingBrain.DataCapture.Views.Questions;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views
{
	public delegate View ViewForQuestionDelegate (ISurveyItem question, SurveyPageAppearance appearance);

	public delegate Page PageForContainerQuestionDelegate (ContainerSurveyItem container, SurveyPageAppearance appearance);

	/// <summary>
	/// Acts as a bridge between Question domain objects and corresponding presentation
	/// objects. We don't want to pollute the domain objects with any presentation specific
	/// methods like 'CreateView'.
	/// </summary>
	public static class QuestionViews
	{
		static QuestionViews ()
		{
			ViewForQuestion = DefaultViewForQuestion;
			PageForContainerQuestion = DefaultPageForContainerQuestion;
		}

		public static ViewForQuestionDelegate ViewForQuestion { get; set; }

		public static PageForContainerQuestionDelegate PageForContainerQuestion { get; set; }

		public static View DefaultViewForQuestion (ISurveyItem item, SurveyPageAppearance appearance)
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
			}

			if (view != null) {
				// place questions in container
				var question = item as IQuestion;
				if (question != null) {
					view = new QuestionInputViewContainer (question, view, appearance);
				}
			}

			return view;
		}

		public static Page DefaultPageForContainerQuestion (ContainerSurveyItem container, SurveyPageAppearance appearance)
		{
			Page page = null;

			if (container is SubpageGroupQuestion) {
				page = new StandardSurveySubpage ();
			} else if (container is SurveyPage) {
				page = new StandardSurveyPage ();
			}

			if (page != null) {
				page.BindingContext = container;
			}

			return page;
		}
	}	
}
