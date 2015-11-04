using System;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views.Questions
{
	public abstract class QuestionInputView : ContentView
	{
		public QuestionInputView (SurveyPageAppearance appearance)
		{
			this.Appearance = appearance;
			HeightRequest = appearance.ItemHeight;
		}

		protected SurveyPageAppearance Appearance { get; private set; }
	}	
}
