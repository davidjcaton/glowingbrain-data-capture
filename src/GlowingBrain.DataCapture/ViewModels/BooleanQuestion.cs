using System;

namespace GlowingBrain.DataCapture.ViewModels
{
	public abstract class BooleanQuestion : Question<bool>
	{
		public override bool HasResponse {
			get { return true; }				
		}
	}
}
