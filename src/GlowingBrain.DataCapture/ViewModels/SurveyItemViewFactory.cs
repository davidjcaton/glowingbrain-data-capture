using System;
using Xamarin.Forms;
using GlowingBrain.DataCapture.Views.Questions;
using GlowingBrain.DataCapture.Views.StaticItems;
using GlowingBrain.DataCapture.Views.Pages;

namespace GlowingBrain.DataCapture.ViewModels
{

	public static class SurveyItemViewFactory
	{
		static SurveyItemViewFactory ()
		{
			Default = new DefaultSurveyItemViewFactory ();
		}

		public static ISurveyItemViewFactory Default { get; set; }
	}

}
