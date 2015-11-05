using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.ViewModels
{

	public class SurveyResponseStore : ISurveyResponseStore
	{
		readonly Dictionary<IQuestion, object> _responseMap = new Dictionary<IQuestion, object> ();

		public event EventHandler<EventArgs<IQuestion>> QuestionResponseChanged;

		public bool SetResponse<TResponse> (IQuestion question, TResponse response)
		{
			var hasChanged = true;

			TResponse oldValue;
			if (TryGetResponse (question, out oldValue)) {
				hasChanged = !EqualityComparer<TResponse>.Default.Equals (response, oldValue);
			}

			_responseMap [question] = response;

			if (hasChanged) {
				OnQuestionResponseChanged (question);
			}

			return hasChanged;
		}

		public bool TryGetResponse<TResponse> (IQuestion question, out TResponse response)
		{
			object result;
			if (_responseMap.TryGetValue (question, out result)) {
				response = (TResponse)result;
				return true;
			}

			response = default (TResponse);
			return false;
		}

		protected virtual void OnQuestionResponseChanged (IQuestion question)
		{
			var handler = QuestionResponseChanged;
			if (handler != null) {
				handler (this, new EventArgs<IQuestion> (question));
			}
		}
	}
	
}
