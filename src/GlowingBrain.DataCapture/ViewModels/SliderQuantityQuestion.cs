using System;

namespace GlowingBrain.DataCapture.ViewModels
{
	public class SliderQuantityQuestion : QuantityQuestion
	{
		public ValueUnit Step { get; set; }
		public bool IsValueVisible { get; set; }

		public SliderQuantityQuestion (ISurveyPage page) : base (page)
		{
			IsValueVisible = true;
		}

		public virtual string GetFormattedValue ()
		{
			if (Response == null) {
				return string.Empty;
			}

			return Response.Value.ToString ("0.##");
		}
	}
}
