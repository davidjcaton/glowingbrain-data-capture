using System;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views
{
	internal static class StandardViews
	{
		public static BoxView CreateSeparator (Style style)
		{
			return new BoxView {
				Style = style
			};
		}
	}	
}
