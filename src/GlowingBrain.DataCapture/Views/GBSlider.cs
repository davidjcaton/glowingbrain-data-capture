using System;
using System.Collections;
using GlowingBrain.DataCapture.Infrastructure;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views
{
	public class GBSlider : Slider
	{
		public GBSlider ()
		{
			this.ValueChanged += (sender, e) => OnValueChanged (e.OldValue, e.NewValue);
		}

		public static BindableProperty IncrementProperty = BindableProperty.Create<GBSlider, double>(
			p => p.Increment,
			0,
			BindingMode.OneWay,
			propertyChanged: OnIncrementChanged);
		
		public double Increment {
			get { return (double)GetValue (IncrementProperty); }
			set { SetValue (IncrementProperty, value); }
		}

		protected virtual void OnValueChanged (double oldValue, double newValue)
		{
			QuantizeValue ();
		}

		protected virtual void OnIncrementChanged (double oldValue, double newValue)
		{
			QuantizeValue ();
		}
			
		protected virtual void QuantizeValue ()
		{
			// capture current state
			var value = Value;
			var increment = Increment;

			// only quantize if increment specified 
			// values <= 0.0 considered as no quantize)
			if (Increment > 0.0) {
				var adjustedValue = Numerics.SnapToInterval (value, increment);
				// only touch value if real change
				if (Math.Abs (adjustedValue - value) > double.Epsilon) {
					Value = adjustedValue;
				}
			}
		}

		static void OnIncrementChanged (BindableObject bindable, double oldValue, double newValue)
		{
			((GBSlider)bindable).OnIncrementChanged (oldValue, newValue);
		}
	}
}
