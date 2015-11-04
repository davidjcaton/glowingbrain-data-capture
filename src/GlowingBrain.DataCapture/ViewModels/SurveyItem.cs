using System;

namespace GlowingBrain.DataCapture.ViewModels
{
	public abstract class SurveyItem : PropertyChangedBase
	{
		public string Id { get; set; }
		public string Caption { get; set; }
		public string Text { get; set; }
		public string Footnote { get; set; }
	}
}
