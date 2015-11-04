using System;

namespace GlowingBrain.DataCapture
{
	public class EventArgs<TValue> : EventArgs
	{
		public EventArgs (TValue value)
		{
			Value = value;
		}

		public TValue Value { get; private set; }
	}
}
