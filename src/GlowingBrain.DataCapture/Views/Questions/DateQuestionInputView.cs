using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views.Questions
{

	public class DateQuestionInputView : QuestionInputView
	{
		public DateQuestionInputView (DateQuestion question, SurveyPageAppearance appearance)
			: base (appearance)
		{
			var picker = new ExtendedDatePicker ();
			picker.HorizontalOptions = LayoutOptions.StartAndExpand;
			picker.VerticalOptions = LayoutOptions.CenterAndExpand;
			picker.PlaceholderText = question.Text;
			picker.BindingContext = question;
			picker.SetBinding (ExtendedDatePicker.ValueProperty, new Binding ("Response", BindingMode.TwoWay));

			Content = picker;
		}
	}
	
}
