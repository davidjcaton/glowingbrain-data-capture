using System;

namespace GlowingBrain.DataCapture.ViewModels
{
	public abstract class ContainerSurveyItem : SurveyItem
	{
		public event EventHandler<EventArgs<SurveyItem>> ChildResponseChanged;

		public ContainerSurveyItem ()
		{
			Children = new SurveyItemCollection (this);
		}

		public SurveyItemCollection Children { get; private set; }

		public virtual void NotifyChildResponseChanged (SurveyItem item)
		{
			OnChildResponseChanged (item);
		}

		protected virtual void OnChildResponseChanged (SurveyItem item)
		{
			var handler = ChildResponseChanged;
			if (handler != null) {
				handler (this, new EventArgs<SurveyItem> (item));
			}
		}
	}
}
