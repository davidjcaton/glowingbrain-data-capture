using System;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views
{
	[ContentProperty ("Content")]
	public class StateContent<TState>
	{
		public TState State { get; set; }
		public View Content { get; set; }
	}	
}
