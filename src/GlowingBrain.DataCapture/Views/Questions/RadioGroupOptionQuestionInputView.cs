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
			readonly SurveyPageAppearance _settings;

			public CustomRadioGroup (SurveyPageAppearance settings)
			{
				_settings = settings;

				UnselectedSource = _settings.UnselectedOptionImageSource;
				SelectedSource = _settings.SelectedOptionImageSource;
			}

			protected override View CreateSeperatorView ()
			{
				return StandardViews.CreateSeparator (_settings.SeparatorColor);
			}

			protected override Option CreateOptionForItem (object item)
			{
				var option = base.CreateOptionForItem (item);
				option.HeightRequest = _settings.ItemHeight;
				return option;
			}
		}
	}
	
}
