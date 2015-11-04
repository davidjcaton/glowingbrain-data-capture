using System;

namespace GlowingBrain.DataCapture.Views
{

	public class ToggleOption : Option
	{
		protected override void OnTapped ()
		{
			IsSelected = !IsSelected;
		}
	}
}
