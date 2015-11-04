using System;
using System.ComponentModel;

namespace GlowingBrain.DataCapture.ViewModels
{
	public interface IQuestion : INotifyPropertyChanged
	{
		bool IsMandatory { get; }
		string ErrorMessage { get; }
		bool HasError { get; }
		bool HasResponse { get; }
		void ClearError ();
		void Validate ();
	}

	public abstract class Question<TResponse> : SurveyItem, IQuestion
	{
		bool _isMandatory;
		TResponse _response;
		string _errorMessage;

		public Question ()
		{
			Validator = _ => {};	
		}

		public TResponse Response {
			get { return _response; }
			set {
				var oldValue = _response;
				if (Set (ref _response, value)) {
					OnResponseChanged (oldValue, value);
				}
			}
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

		protected virtual void OnResponseChanged (TResponse oldValue, TResponse newValue)
		{
		}
	}
}
