using System;

namespace GlowingBrain.DataCapture
{
	public class OptionValue
	{
		public string Value { get; set; }
		public string Text { get; set; }

		public override string ToString ()
		{
			return Text;
		}
	}
}
