using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views.Questions
{

	public class FreeTextQuestionInputView : QuestionInputView 
	{
		public FreeTextQuestionInputView (FreeTextQuestion question, SurveyPageAppearance appearance)
			: base (appearance)
		{
			var entry = new GBEntry ();
			entry.HorizontalOptions = LayoutOptions.FillAndExpand;
			entry.VerticalOptions = LayoutOptions.FillAndExpand;
			entry.Placeholder = question.Text;
			entry.BindingContext = question;
			entry.SetBinding (Entry.TextProperty, new Binding ("Response", BindingMode.TwoWay));
			Content = entry;
		}
	}
	
}
