using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views.Questions
{
	public class RadioGroupOptionQuestionInputView : QuestionInputView
	{
		public RadioGroupOptionQuestionInputView (OptionQuestion question, SurveyPageAppearance appearance)
			: base (appearance)
		{
			var radioGroup = new CustomRadioGroup (appearance);
			radioGroup.HorizontalOptions = LayoutOptions.FillAndExpand;
			radioGroup.VerticalOptions = LayoutOptions.Fill;
			radioGroup.BindingContext = question;
			radioGroup.ItemsSource = question.OptionValues;
			radioGroup.SetBinding (OptionValuePicker.ValueProperty, new Binding ("SelectedOption", BindingMode.TwoWay));

			HeightRequest = -1;
			Content = radioGroup;
		}

		class CustomRadioGroup : RadioGroup
		{
			readonly SurveyPageAppearance _appearance;

			public CustomRadioGroup (SurveyPageAppearance appearance)
			{
				_appearance = appearance;

				UnselectedSource = _appearance.UnselectedOptionImageSource;
				SelectedSource = _appearance.SelectedOptionImageSource;
			}

			protected override View CreateSeperatorView ()
			{
				return StandardViews.CreateSeparator (_appearance.SeperatorStyle);
			}

			protected override Option CreateOptionForItem (object item)
			{
				var option = base.CreateOptionForItem (item);
				option.Style = _appearance.QuestionOptionStyle;
				return option;
			}
		}
	}
	
}
