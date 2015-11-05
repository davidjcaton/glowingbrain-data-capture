using System;
using System.ComponentModel;

namespace GlowingBrain.DataCapture.ViewModels
{
	public interface ISurveyItem : INotifyPropertyChanged
	{
		ISurveyPage Page { get; }
		string Id { get; set; }
		string Caption { get; set; }
		string Text { get; set; }
		string Footnote { get; set; }
		object Tag { get; set; }
	}	
}
