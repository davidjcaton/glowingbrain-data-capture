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

	public class SurveyResponseStore : ISurveyResponseStore
	{
		readonly Dictionary<IQuestion, object> _responseMap = new Dictionary<IQuestion, object> ();

		public event EventHandler<EventArgs<IQuestion>> QuestionResponseChanged;

		public bool SetResponse<TResponse> (IQuestion question, TResponse response)
		{
			var hasChanged = false;

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

	public interface IQuestion : INotifyPropertyChanged
	{
		//string Id { get; }
		bool IsMandatory { get; }
		string ErrorMessage { get; }
		bool HasError { get; }
		bool HasResponse { get; }
		void ClearError ();
		void Validate ();
		ISurveyPage Page { get; }
	}

	public abstract class Question<TResponse> : SurveyItem, IQuestion
	{
		readonly ISurveyPage _page;

		bool _isMandatory;
		string _errorMessage;

		protected Question (ISurveyPage page)
		{
			_page = page;
			Validator = _ => {};	
		}

		public ISurveyPage Page {
			get { return _page; }
		}

		public TResponse Response {
			get { return GetResponse (); }
			set {
				if (SetResponse (value)) {
					OnResponseChanged ();
				}
			}
		}

		protected TResponse GetResponse ()
		{
			TResponse response;
			if (!_page.Survey.ResponseStore.TryGetResponse (this, out response)) {
				response = default (TResponse);
			}
			return response;
		}

		protected bool SetResponse (TResponse response)
		{
			return _page.Survey.ResponseStore.SetResponse (this, response);
		}

		public Action<Question<TResponse>> Validator { get; set; }
				
		public abstract bool HasResponse { get; }

		public bool IsMandatory {
			get { return _isMandatory; }
			set { Set (ref _isMandatory, value); }
		}

		public string ErrorMessage {
			get { return _errorMessage; }
			set { 
				if (Set (ref _errorMessage, value)) {
					NotifyPropertyChanged ("HasError");
				}
			}
		}

		public bool HasError {
			get { return !String.IsNullOrWhiteSpace (_errorMessage); }
		}

		public void ClearError ()
		{
			ErrorMessage = null;
		}

		public void Validate ()
		{
			ClearError ();
			Validator (this);
		}

		protected virtual void OnResponseChanged ()
		{
			NotifyPropertyChanged ("Response");
		}
	}
}
