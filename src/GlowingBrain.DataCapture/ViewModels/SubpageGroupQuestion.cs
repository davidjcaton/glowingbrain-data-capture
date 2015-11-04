using System;

namespace GlowingBrain.DataCapture.ViewModels
{
	public class SubpageGroupQuestion : ContainerSurveyItem
	{
		public SubpageGroupQuestion ()			
		{
			GetSummaryText = question => question.Text;  
		}

		public virtual string SummaryText {
			get { return OnGetSummaryText (); }
		}

		public Func<ContainerSurveyItem, string> GetSummaryText { get; set; }

		protected virtual string OnGetSummaryText ()
		{
			return GetSummaryText (this);
		}

		public virtual void NotifySummaryTextChanged ()
		{
			NotifyPropertyChanged ("SummaryText");
		}

		protected override void OnChildResponseChanged (SurveyItem item)
		{
			base.OnChildResponseChanged (item);
			NotifySummaryTextChanged ();
		}
	}
}
