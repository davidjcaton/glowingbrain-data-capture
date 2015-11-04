using System;

namespace GlowingBrain.DataCapture.ViewModels
{
	public class DateQuestion : Question<DateTime>
	{
		public override bool HasResponse {
			get { return true; }
		}
	}
}
