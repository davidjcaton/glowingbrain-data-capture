using System;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.ViewModels
{
	public interface ISurveyItemContainer
	{
		SurveyItemCollection Children { get; }
		void NotifyChildResponseChanged (ISurveyItem item);
	}

	public abstract class ContainerSurveyItem : SurveyItem, ISurveyItemContainer
	{
		public event EventHandler<EventArgs<ISurveyItem>> ChildResponseChanged;

		public ContainerSurveyItem (ISurveyPage page) : base (page)
		{
			Children = new SurveyItemCollection (this);
		}

		public SurveyItemCollection Children { get; private set; }

		public virtual void NotifyChildResponseChanged (ISurveyItem item)
		{
			OnChildResponseChanged (item);
		}

		protected virtual void OnChildResponseChanged (ISurveyItem item)
		{
			var handler = ChildResponseChanged;
			if (handler != null) {
				handler (this, new EventArgs<ISurveyItem> (item));
			}
		}
	}
}
