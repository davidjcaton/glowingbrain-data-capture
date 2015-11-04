using System;

namespace GlowingBrain.DataCapture.ViewModels
{
	public interface IQuestion
	{
		bool IsMandatory { get; }
		string ErrorMessage { get; }
		bool HasError { get; }
		bool HasResponse { get; }
	}

	public abstract class Question<TResponse> : SurveyItem, IQuestion
	{
		bool _isMandatory;
		TResponse _response;
		string _errorMessage;

		public TResponse Response {
			get { return _response; }
			set {
				var oldValue = _response;
				if (Set (ref _response, value)) {
					OnResponseChanged (oldValue, value);
				}
			}
		}

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

		protected virtual void OnResponseChanged (TResponse oldValue, TResponse newValue)
		{
		}
	}
}
