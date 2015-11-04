using System;

namespace GlowingBrain.DataCapture.ViewModels
{
	public abstract class BooleanQuestion : Question<bool>
	{
		protected BooleanQuestion (ISurveyPage page) : base (page)
		{
		}

		public override bool HasResponse {
			get { return true; }				
		}
	}
}
