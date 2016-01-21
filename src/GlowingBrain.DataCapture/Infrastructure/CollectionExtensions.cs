using System;
using System.Collections.Generic;
using GlowingBrain.DataCapture;

namespace System.Collections
{
	internal static class CollectionExtensions
	{
		public static List<object> ToList (this IEnumerable items)
		{
			var list = new List<object> ();
			foreach (var item in items) {
				list.Add (item);
			}
			return list;
		}

		public static ListPosition GetListPosition (this IList items, int index)
		{
			if (index == 0) {
				return ListPosition.First;
			}

			if (index == items.Count - 1) {
				return ListPosition.Last;
			}

			return ListPosition.Middle;
		}
	}

}
