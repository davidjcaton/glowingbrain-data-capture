using System.ComponentModel;

namespace GlowingBrain.DataCapture.ViewModels
{
	public interface ISurvey : INotifyPropertyChanged
	{
		string Title { get; }
		double Progress { get; }
		ISurveyPage CurrentPage { get; }
		ISubmitPageResult SubmitPage (ISurveyPage page);
		INavigateBackResult NavigateBack (ISurveyPage page);
	}	
}
