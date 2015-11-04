using System;
using GlowingBrain.DataCapture.ViewModels;
using System.Linq;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views.Questions
{

	public abstract class QuantityQuestionInputView : QuestionInputView
	{
		protected QuantityQuestionInputView (SurveyPageAppearance appearance)
			: base (appearance)
		{			
		}

		protected virtual OptionValuePicker BuildUnitPicker (QuantityQuestion question)
		{
			var picker = new OptionValuePicker {
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				PlaceholderText = "Unit",
				ItemsSource = question.UnitOptions
			};

			picker.Value = question.UnitOptions.FirstOrDefault (x => x.Value == question.DefaultUnit);

			return picker;
		}
	}
	
}
