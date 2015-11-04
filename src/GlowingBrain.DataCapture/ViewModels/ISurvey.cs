using System.ComponentModel;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.ViewModels
{
	public interface ISurvey : INotifyPropertyChanged
	{
		string Title { get; }
		double Progress { get; }
		ISurveyPage CurrentPage { get; }
		ISubmitPageResult SubmitPage (IEnumerable<IQuestion> questions);
		INavigateBackResult NavigateBack ();
	}	
}
