using System;
using System.Collections.Generic;
using System.Linq;

namespace GlowingBrain.DataCapture.ViewModels
{
	public static class QuestionCollectionExtensions
	{
		public static IEnumerable<CheckboxBooleanQuestion> Checked (this IEnumerable<SurveyItem> questions)
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

		public static IList<SurveyItem> Descendants (this SurveyItem item)
		{
			var list = new List<SurveyItem> ();
			CollectChildrenRecursive (item, list);
			return list;
		}

		static void CollectChildrenRecursive (SurveyItem item, IList<SurveyItem> children)
		{
			var container = item as ContainerSurveyItem;
			if (container != null) {
				foreach (var child in container.Children) {
					children.Add (child);
					CollectChildrenRecursive (child, children);
				}
			}
		}
	}
}
