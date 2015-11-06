using System;

namespace GlowingBrain.DataCapture.Infrastructure
{
	internal static class Numerics
	{
		public static double SnapToInterval (double value, double interval)
		{
			return Math.Round (value / interval, MidpointRounding.AwayFromZero) * interval;
		}

		public static int SnapToInterval (int value, int interval)
		{
			return ((int)Math.Round ((double)value / (double)interval, MidpointRounding.AwayFromZero)) * interval;
		}
	}
}
