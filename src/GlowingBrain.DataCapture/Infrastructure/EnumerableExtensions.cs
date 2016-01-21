using System;
using System.Collections.Generic;
using GlowingBrain.DataCapture;

namespace System.Collections
{

	internal static class EnumerableExtensions
	{
		public static void Each<T>(this IEnumerable<T> items, Action<T> action)
		{
			foreach (var item in items) {
				action (item);
			}
		}
	}
}
