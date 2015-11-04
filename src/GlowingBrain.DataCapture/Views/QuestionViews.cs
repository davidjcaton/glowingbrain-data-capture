using System;
using GlowingBrain.DataCapture.ViewModels;
using GlowingBrain.DataCapture.Views.Pages;
using GlowingBrain.DataCapture.Views.Questions;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views
{
	public delegate View ViewForQuestionDelegate (SurveyItem question, SurveyPageAppearance appearance);

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

		public static View DefaultViewForQuestion (SurveyItem question, SurveyPageAppearance appearance)
		{
			if (question is DateQuestion) {
				return new DateQuestionInputView ((DateQuestion)question, appearance);
			} else if (question is PickerOptionQuestion) {
				return new PickerOptionQuestionInputView ((OptionQuestion)question, appearance);
			} else if (question is RadioOptionQuestion) {
				return new RadioGroupOptionQuestionInputView ((OptionQuestion)question, appearance);
			} else if (question is NumericEntryQuantityQuestion) {
				return new NumericEntryQuantityQuestionInputView ((QuantityQuestion)question, appearance);
			} else if (question is CheckboxBooleanQuestion) {
				return new CheckboxBooleanQuestionInputView ((BooleanQuestion)question, appearance);
			} else if (question is InlineGroupQuestion) {
				return new InlineGroupQuestionInputView ((InlineGroupQuestion)question, appearance);
			} else if (question is SubpageGroupQuestion) {
				return new SubpageGroupQuestionInputView ((SubpageGroupQuestion)question, appearance);
			} else if (question is FreeTextQuestion) {
				return new FreeTextQuestionInputView ((FreeTextQuestion)question, appearance);
			} else if (question is SliderQuantityQuestion) {
				return new SliderQuantityQuestionInputView ((SliderQuantityQuestion)question, appearance);
			}

			return null;
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
