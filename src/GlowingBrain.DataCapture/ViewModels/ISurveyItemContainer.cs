using System;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.ViewModels
{
	public interface ISurveyItemContainer
	{
		SurveyItemCollection Children { get; }
		void NotifyChildResponseChanged (ISurveyItem item);
	}	
}
