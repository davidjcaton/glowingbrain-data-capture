//using System;
//
//namespace GlowingBrain.DataCapture.ViewModels
//{
//
//	public static class QuestionUnits
//	{
//		public static QuestionUnitPreferences GetUnitsForQuestion (QuantityQuestion question)
//		{
//			switch (question.Quantity) {
//			case Quantity.Length:
//				return new QuestionUnitPreferences ("m", new List<OptionValue> { 
//					new OptionValue { Value = "cm", Text = "cm" },
//					new OptionValue { Value = "m", Text = "m" }
//				});
//			}
//
//			return QuestionUnitPreferences.Empty;
//		}
//	}
//	
//}
