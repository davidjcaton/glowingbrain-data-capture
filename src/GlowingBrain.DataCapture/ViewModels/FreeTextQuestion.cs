using System;

namespace GlowingBrain.DataCapture.ViewModels
{
	public class FreeTextQuestion : Question<string>
	{
		public FreeTextQuestion (ISurveyPage page) : base (page)
		{
		}

		public override bool HasResponse {
			get { return !String.IsNullOrWhiteSpace (Response); }
		}
	}
}
