using System;
using System.Collections.Generic;
using GlowingBrain.DataCapture.ViewModels;
using GlowingBrain.DataCapture;

namespace Capture
{
	public static class TestData
	{
		public static class Surveys
		{
			static Surveys ()
			{
				Initialize ();
			}

			public static Survey Example1 { get; private set; }

			static void Initialize ()
			{
				Example1 = CreateExample1 ();	
			}

			static Survey CreateExample1 ()
			{
				var survey = new Survey { 
					Title = "BMI Calculator"
				};

				var page1 = new SurveyPage (survey);
				page1.Caption = "About you";
				page1.Children.Add (new NumericEntryQuantityQuestion {
					Id = "height",
					IsMandatory = true,
					Caption = "Height",
					Footnote = "We need to know your height",
					UnitOptions = new List<OptionValue> { 
						new OptionValue { Value = "m", Text = "m" }, 
						new OptionValue { Value = "cm", Text = "cm" }
					},
					Minimum = new ValueUnit { Value = 1.0, Unit = "m" },
					Maximum = new ValueUnit { Value = 2.5, Unit = "m" },
					Response = new ValueUnit { Value = 1.75, Unit = "m" }
				});
				survey.Pages.Add (page1);

				var page2 = new SurveyPage (survey);
				page2.Caption = "About you";
				page2.Children.Add (new SliderQuantityQuestion {
					Id = "weight",
					IsMandatory = true,
					Caption = "Weight",
					Footnote = "We need to know your weight",
					UnitOptions = new List<OptionValue> { 
						new OptionValue { Value = "kg", Text = "kg" }, 
						new OptionValue { Value = "[lb_av]", Text = "lbs" }
					},
					Minimum = new ValueUnit { Value = 40.0, Unit = "kg" },
					Maximum = new ValueUnit { Value = 250, Unit = "kg" },
					Response = new ValueUnit { Value = 70, Unit = "kg" }
				});
				survey.Pages.Add (page2);

				return survey;
			}
		}
	}
}
