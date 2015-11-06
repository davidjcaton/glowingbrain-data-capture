using System;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.Units
{
	public class Unit : IEquatable<Unit>
	{
		public static readonly Unit Kilometer = new Unit (Quantity.Length, "km", 1000.0);
		public static readonly Unit Meter = new Unit (Quantity.Length, "m");
		public static readonly Unit Centimeter = new Unit (Quantity.Length, "cm", 0.01);
		public static readonly Unit Millimeter = new Unit (Quantity.Length, "mm", 0.001);
		public static readonly Unit Inch = new Unit (Quantity.Length, "[in_i]", 0.01 * 2.54);
		public static readonly Unit Foot = new Unit (Quantity.Length, "[ft_i]", 0.01 * 2.54 * 12.0);

		public static readonly Unit Kilogram = new Unit (Quantity.Mass, "kg", 1000.0);
		public static readonly Unit Gram = new Unit (Quantity.Mass, "g");
		public static readonly Unit Milligram = new Unit (Quantity.Mass, "mg", 0.001);
		public static readonly Unit Grain = new Unit (Quantity.Mass, "[gr]", 0.001 * 64.79891);
		public static readonly Unit Pound = new Unit (Quantity.Mass, "[lb_av]", 7000.0 * 0.001 * 64.79891);
		public static readonly Unit Ounce = new Unit (Quantity.Mass, "[oz_av]", (7000.0 * 0.001 * 64.79891) / 16.0);

		public static readonly Unit Second = new Unit (Quantity.Time, "s");
		public static readonly Unit Millisecond = new Unit (Quantity.Time, "ms", 0.001);
		public static readonly Unit Minute = new Unit (Quantity.Time, "min", 60.0);
		public static readonly Unit Hour = new Unit (Quantity.Time, "h", 60.0 * 60.0);
		public static readonly Unit Day = new Unit (Quantity.Time, "d", 60.0 * 60.0 * 24.0);

		static readonly Lazy<Dictionary<string, Unit>> _codeToUnitMap = new Lazy<Dictionary<string, Unit>> (BuildCodeToUnitMap);

		public Unit (Quantity quantity, string code, double multipler = 1.0)
		{
			this.Quantity = quantity;
			this.Code = code;
			this.Multiplier = multipler;
		}

		public Quantity Quantity { get; private set; }
		public double Multiplier { get; private set; }
		public string Code { get; private set; }

		public bool Equals (Unit other)
		{
			if (ReferenceEquals (null, other)) {
				return false;
			}

			if (ReferenceEquals (this, other)) {
				return true;
			}

			// only code needed for equality
			return String.Equals (this.Code, other.Code);
		}

		public override bool Equals (object other)
		{
			return Equals (other as Unit);
		}

		public override int GetHashCode ()
		{
			unchecked {
				var result = Multiplier.GetHashCode ();
				result = (result * 397) ^ (Quantity.GetHashCode ());
				result = (result * 397) ^ (Code != null ? Code.GetHashCode () : 0);
				return result;
			}
		}

		public static bool TryParse (string text, out Unit result)
		{
			if (text == null) {
				result = null;
				return false;
			}

			return _codeToUnitMap.Value.TryGetValue (text, out result);
		}

		static Dictionary<string, Unit> BuildCodeToUnitMap ()
		{			
			var map = new Dictionary<string, Unit> ();

			Action<Unit> add = (unit) => map.Add (unit.Code, unit);

			add (Kilometer);
			add (Meter);
			add (Centimeter);
			add (Millimeter);
			add (Inch);
			add (Foot);

			add (Kilogram);
			add (Gram);
			add (Milligram);
			add (Grain);
			add (Pound);
			add (Ounce);

			add (Second);
			add (Millisecond);
			add (Minute);
			add (Hour);
			add (Day);

			return map;
		}
	}	
}
