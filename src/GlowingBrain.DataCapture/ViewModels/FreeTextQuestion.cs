using System;

namespace GlowingBrain.DataCapture.ViewModels
{
	public class FreeTextQuestion : Question<string>
	{
		public override bool HasResponse {
			get { return !String.IsNullOrWhiteSpace (Response); }
		}
	}
}
