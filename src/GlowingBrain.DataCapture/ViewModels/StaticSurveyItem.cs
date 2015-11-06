using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.ViewModels
{
	public abstract class StaticSurveyItem : SurveyItem, IStaticSurveyItem
	{
		protected StaticSurveyItem (ISurveyPage page) : base (page)
		{
		}
	}
}
