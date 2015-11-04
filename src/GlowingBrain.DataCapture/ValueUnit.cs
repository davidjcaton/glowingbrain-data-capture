using System;

namespace GlowingBrain.DataCapture
{
	public class ValueUnit : IEquatable<ValueUnit>
	{
		public double Value { get; set; }

		public string Unit { get; set; }

		public bool Equals (ValueUnit other)
		{
			if (ReferenceEquals (null, other)) {
				return false;
			}

			if (ReferenceEquals (this, other)) {
				return true;
			}

			var result = this.Value == other.Value &&
				String.Equals (this.Unit, other.Unit);

			return result;
		}

		public override bool Equals (object other)
		{
			return Equals (other as ValueUnit);
		}

		public override int GetHashCode ()
		{
			unchecked {
				var result = (Unit != null ? Unit.GetHashCode () : 0);
				result = (result * 397) ^ (Value.GetHashCode ());
				return result;
			}
		}
	}
}

