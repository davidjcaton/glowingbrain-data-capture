using System;
using System.Collections.Generic;
using GlowingBrain.DataCapture.Units;
using System.Linq;

namespace GlowingBrain.DataCapture.ViewModels
{
	public abstract class QuantityQuestion : Question<ValueUnit>
	{
		ValueUnit _minimum;
		ValueUnit _maximum;
		Quantity _quantity;
		List<OptionValue> _unitOptions;
		string _defaultUnit;

		protected QuantityQuestion (ISurveyPage page) : base (page)
		{
		}

		public override bool HasResponse {
			get { return Response != null; }
		}

		public ValueUnit Minimum {
			get { return _minimum; }
			set { 
				if (Set (ref _minimum, value)) {
					OnMinimumChanged ();
				}
			}
		}

		public ValueUnit Maximum {
			get { return _maximum; }
			set { 
				if (Set (ref _maximum, value)) {
					OnMaximumChanged ();
				}
			}
		}

		public Quantity Quantity {
			get { return _quantity; }
			set { 
				if (Set (ref _quantity, value)) {
					OnQuantityChanged ();
				}
			}
		}

		public List<OptionValue> UnitOptions {
			get { return _unitOptions; }
			set { 
				if (Set (ref _unitOptions, value)) {
					OnUnitOptionsChanged ();
				}
			}
		}

		public string DefaultUnit {
			get { return _defaultUnit; }
			set {
				if (Set (ref _defaultUnit, value)) {
					OnDefaultUnitChanged ();
				}
			}
		}

		public bool HasUnitOptions {
			get { return _unitOptions != null && _unitOptions.Any (); }
		}

		protected virtual void OnQuantityChanged ()
		{
		}

		protected virtual void OnUnitOptionsChanged ()
		{
		}

		protected virtual void OnDefaultUnitChanged ()
		{
		}

		protected virtual void OnMinimumChanged ()
		{
		}

		protected virtual void OnMaximumChanged ()
		{
		}
	}	
}
