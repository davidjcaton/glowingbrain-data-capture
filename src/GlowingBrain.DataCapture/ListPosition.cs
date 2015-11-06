using System;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture
{
	public enum ListPosition
	{
		First,
		Last,
		Middle
	}

	public static class ListPositionExtensions
	{
		public static LayoutOptions GetLayoutOption (this ListPosition value)
		{
			if (value == ListPosition.First) {
				return LayoutOptions.StartAndExpand;
			}

			if (value == ListPosition.Last) {
				return LayoutOptions.EndAndExpand;
			}

			return LayoutOptions.CenterAndExpand;
		}
	}
}
