using System;

namespace GlowingBrain.DataCapture.ViewModels
{
	public class DateQuestion : Question<DateTime>
	{
		public DateQuestion (ISurveyPage page) : base (page)
		{
		}

		public override bool HasResponse {
			get { return true; }
		}
	}
}
