using System;
using System.Collections.Generic;

namespace System.Collections
{
	internal static class EnumerableExtensions
	{
		public static List<object> ToList (this IEnumerable items)
		{
			var list = new List<object> ();
			foreach (var item in items) {
				list.Add (item);
			}
			return list;
		}
	}
}
