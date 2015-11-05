using System;
using System.ComponentModel;

namespace GlowingBrain.DataCapture.ViewModels
{
	public abstract class SurveyItem : PropertyChangedBase, ISurveyItem
	{
		readonly ISurveyPage _page;

		public SurveyItem (ISurveyPage page)
		{
			_page = page;	
		}

		public ISurveyPage Page {
			get { return _page; }
		}

		public string Id { get; set; }
		public string Caption { get; set; }
		public string Text { get; set; }
		public string Footnote { get; set; }
		public object Tag { get; set; }
	}
}
