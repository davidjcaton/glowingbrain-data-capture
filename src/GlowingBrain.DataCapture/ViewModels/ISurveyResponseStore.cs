using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.ViewModels
{
	public interface ISurveyResponseStore
	{
		event EventHandler<EventArgs<IQuestion>> QuestionResponseChanged;

		bool SetResponse<TResponse> (IQuestion question, TResponse response);
		bool TryGetResponse<TResponse> (IQuestion question, out TResponse response);
	}
	
}
