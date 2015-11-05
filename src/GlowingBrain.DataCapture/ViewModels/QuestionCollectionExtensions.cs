using System;
using System.Collections.Generic;
using System.Linq;

namespace GlowingBrain.DataCapture.ViewModels
{
	public static class QuestionCollectionExtensions
	{
		public static IEnumerable<CheckboxBooleanQuestion> Checked (this IEnumerable<ISurveyItem> questions)
		{
			return questions
				.OfType<CheckboxBooleanQuestion> ()
				.Where (question => question.Response);
		}

		public static IEnumerable<CheckboxBooleanQuestion> Checked (this IEnumerable<CheckboxBooleanQuestion> questions)
		{
			return questions
				.Where (question => question.Response);
		}

		public static IList<ISurveyItem> Descendants (this ISurveyItemContainer container)
		{
			var list = new List<ISurveyItem> ();
			CollectChildrenRecursive (container, list);
			return list;
		}

		static void CollectChildrenRecursive (ISurveyItemContainer container, IList<ISurveyItem> children)
		{
			foreach (var child in container.Children) {
				children.Add (child);
				var childContainer = child as ISurveyItemContainer;
				if (childContainer != null) {
					CollectChildrenRecursive (childContainer, children);
				}
			}
		}
	}
}
