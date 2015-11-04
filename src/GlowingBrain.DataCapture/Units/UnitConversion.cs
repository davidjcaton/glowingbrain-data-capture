using System;

namespace GlowingBrain.DataCapture.Units
{
	public static class UnitConversion
	{
		public static bool TryConvertUnit (double value, Unit from, Unit to, out double result)
		{
			if (from == null)
				throw new ArgumentNullException ("from");

			if (to == null)
				throw new ArgumentNullException ("to");

			if (!to.Quantity.Equals (from.Quantity)) {
				result = double.NaN;
				return false;
			}

			if (to.Equals (from)) {
				result = value;
				return true;
			}

			result = (value * from.Multiplier) / (to.Multiplier);
			return true;
		}

		public static bool TryConvertUnit (double value, string fromUnitCode, string toUnitCode, out double result)
		{
			result = double.NaN;

			Unit from;
			if (!Unit.TryParse (fromUnitCode, out from)) {
				return false;
			}

			Unit to;
			if (!Unit.TryParse (toUnitCode, out to)) {
				return false;
			}

			return TryConvertUnit (value, from, to, out result);
		}
	}	
}
