using System;
using Xamarin.Forms;
using GlowingBrain.DataCapture.ViewModels;

namespace GlowingBrain.DataCapture.Views.Questions
{
	public abstract class QuestionInputView : ContentView
	{
		public QuestionInputView (SurveyPageAppearance appearance)
		{
			this.Appearance = appearance;
			this.Style = appearance.QuestionInputViewStyle;
		}

		protected SurveyPageAppearance Appearance { get; private set; }
	}	
}
