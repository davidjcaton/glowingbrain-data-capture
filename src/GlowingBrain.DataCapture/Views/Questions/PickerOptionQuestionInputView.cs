using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views.Questions
{

	public class PickerOptionQuestionInputView : QuestionInputView
	{
		public PickerOptionQuestionInputView (OptionQuestion question, SurveyPageAppearance appearance)
			: base (appearance)
		{
			var picker = new OptionValuePicker ();
			picker.HorizontalOptions = LayoutOptions.StartAndExpand;
			picker.VerticalOptions = LayoutOptions.CenterAndExpand;
			picker.PlaceholderText = question.Text;
			picker.BindingContext = question;
			picker.ItemsSource = question.OptionValues;
			picker.SetBinding (OptionValuePicker.ValueProperty, new Binding ("SelectedOption", BindingMode.TwoWay));

			Content = picker;
		}
	}
	
}
