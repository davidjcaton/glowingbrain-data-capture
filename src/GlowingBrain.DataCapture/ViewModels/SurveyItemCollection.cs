using System;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.ViewModels
{
	public class SurveyItemCollection : List<SurveyItem>
	{
		readonly ContainerSurveyItem _container;

		public SurveyItemCollection (ContainerSurveyItem container)
		{			
			_container = container;
		}

		public new void Add (SurveyItem item)
		{
			base.Add (item);

			var containerItem = item as ContainerSurveyItem;
			if (containerItem != null) {
				containerItem.ChildResponseChanged += (sender, e) => {
					OnSurveyItemResponseChanged (e.Value);
				};
			} else {
				item.PropertyChanged += (sender, e) => {
					if (e.PropertyName == "Response") {
						OnSurveyItemResponseChanged (item);
					}
				};
			}
		}

		public new void AddRange (IEnumerable<SurveyItem> items)
		{
			if (items != null) {
				foreach (var item in items) {
					Add (item);
				}
			}
		}

		protected virtual void OnSurveyItemResponseChanged (SurveyItem item)
		{
			_container.NotifyChildResponseChanged (item);
		}
	}
	
}
