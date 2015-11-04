using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views.Questions
{
	public class CheckboxBooleanQuestionInputView : QuestionInputView
	{
		public CheckboxBooleanQuestionInputView (BooleanQuestion question, SurveyPageAppearance appearance)
			: base (appearance)
		{
			var option = new ToggleOption ();
			option.HorizontalOptions = LayoutOptions.FillAndExpand;
			option.VerticalOptions = LayoutOptions.CenterAndExpand;
			option.UnselectedSource = appearance.UnselectedCheckboxImageSource;
			option.SelectedSource = appearance.SelectedCheckboxImageSource;
			option.BindingContext = question;
			option.SetBinding (Option.TextProperty, new Binding ("Text", BindingMode.OneWay));
			option.SetBinding (Option.IsSelectedProperty, new Binding ("Response", BindingMode.TwoWay));

			Content = option;
		}
	}
	
}
