using System;

namespace GlowingBrain.DataCapture
{
	public interface IResult
	{
		bool IsSuccess { get; }
	}

	public interface IResultValue<TValue> : IResult
	{
		TValue Value { get; }
	}

	public class ResultValue<TValue> : IResultValue<TValue>
	{
		public ResultValue (bool isSuccess, TValue value = default (TValue))
		{
			this.IsSuccess = isSuccess;
			this.Value = value;
		}

		public bool IsSuccess {
			get;
			private set;
		}

		public TValue Value {
			get;
			private set;
		}
	}
}
