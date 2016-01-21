using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.ViewModels
{
	public abstract class Question<TResponse> : SurveyItem, IQuestion
	{
		bool _isMandatory;
		string _errorMessage;

		protected Question (ISurveyPage page) : base (page)
		{
			Validator = _ => {};	
		}

		public TResponse Response {
			get { return GetResponse (); }
			set {
				if (SetResponse (value)) {
					OnResponseChanged ();
				}
			}
		}

		public void Commit ()
		{
			// Explanation:
			// Certain questions like boolean questions have an "implicit" default value of 
			// false. No user interaction is needed for them to have this value. As such,
			// we need a mechanism for default values of such questions to be pushed to the
			// underlying response store.
			if (HasResponse) {
				SetResponse (Response);
			}
		}

		protected TResponse GetResponse ()
		{
			TResponse response;
			if (!Page.Survey.ResponseStore.TryGetResponse (this, out response)) {
				response = default (TResponse);
			}
			return response;
		}

		protected bool SetResponse (TResponse response)
		{
			return Page.Survey.ResponseStore.SetResponse (this, response);
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
