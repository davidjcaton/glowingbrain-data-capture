using System;

namespace GlowingBrain.DataCapture
{
	public static class ValueUnitExtensions
	{
		public static bool TryGetValue (this ValueUnit valueUnit, string targetUnit, out double result)
		{
			result = double.NaN;
			if (valueUnit == null) {
				return false;
			}

			return SurveyExecutionContext.Default.TryConvertUnit (valueUnit.Value, valueUnit.Unit, targetUnit, out result);
		}
	}	
}
