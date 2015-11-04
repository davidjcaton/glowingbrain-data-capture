using System;
using GlowingBrain.DataCapture.Units;

namespace GlowingBrain.DataCapture
{
	public class SurveyExecutionContext
	{
		public delegate bool TryConvertUnitsDelegate (double value, string fromUnit, string toUnit, out double result);

		//public delegate QuestionUnitPreferences GetUnitsForQuestionDelegate (QuantityQuestion question);	

		static SurveyExecutionContext ()
		{
			Default = new SurveyExecutionContext {
				TryConvertUnit = UnitConversion.TryConvertUnit,
				//GetUnitsForQuestion = QuestionUnits.GetUnitsForQuestion
			};
		}

		public TryConvertUnitsDelegate TryConvertUnit { get; set; }

		//public GetUnitsForQuestionDelegate GetUnitsForQuestion { get; set; }

		public static SurveyExecutionContext Default { get; set; }
	}	
}
