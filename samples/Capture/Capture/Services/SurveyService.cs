using System.Collections.Generic;
using GlowingBrain.DataCapture.ViewModels;

namespace Capture.Services
{
	public class SurveyService
	{
		public IList<Survey> GetSurveys ()
		{
			return new List<Survey> { TestData.Surveys.Example1 };
		}
	}
}

