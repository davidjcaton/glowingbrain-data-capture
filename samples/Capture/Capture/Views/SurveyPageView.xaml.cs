using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Capture.Services;
using System.Linq;

namespace Capture.Views
{
	public partial class SurveyPageView : ContentPage
	{
		public SurveyPageView ()
		{
			InitializeComponent ();

			var surveyService = new SurveyService ();
			var survey = surveyService.GetSurveys ().First ();

			BindingContext = survey;
		}
	}
}

