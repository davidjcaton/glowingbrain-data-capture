using System;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views
{
	internal static class StandardViews
	{
		public static BoxView CreateSeparator (Color color)
		{
			var separator = new BoxView {
				HeightRequest = 1,
				Color = color
			};
			return separator;
		}
	}	
}
