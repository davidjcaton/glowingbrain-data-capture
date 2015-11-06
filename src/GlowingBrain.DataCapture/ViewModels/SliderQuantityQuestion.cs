using System;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.ViewModels
{
	public class SliderQuantityQuestion : QuantityQuestion
	{
		public SliderQuantityQuestion (ISurveyPage page) : base (page)
		{
			IsValueVisible = true;
		}

		public ValueUnit Increment { get; set; }

		public bool IsValueVisible { get; set; }

		public IEnumerable<string> Labels { get; set; }

		public virtual string GetFormattedValue ()
		{
			if (Response == null) {
				return string.Empty;
			}

			return Response.Value.ToString ("0.##");
		}
	}
}
