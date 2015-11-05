using System;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.ViewModels
{
	public class SurveyItemCollection : List<ISurveyItem>
	{
		readonly ISurveyItemContainer _container;

		public SurveyItemCollection (ISurveyItemContainer container)
		{			
			_container = container;
		}

		public new void Add (ISurveyItem item)
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

		public new void AddRange (IEnumerable<ISurveyItem> items)
		{
			if (items != null) {
				foreach (var item in items) {
					Add (item);
				}
			}
		}

		protected virtual void OnSurveyItemResponseChanged (ISurveyItem item)
		{
			_container.NotifyChildResponseChanged (item);
		}
	}
	
}
