using System;

namespace GlowingBrain.DataCapture.Views
{

	public class OptionValuePicker : ExtendedPicker<OptionValue>
	{
		protected override bool ShouldShowPlaceholder (OptionValue value)
		{
			return value == null;
		}
	}
	
}
