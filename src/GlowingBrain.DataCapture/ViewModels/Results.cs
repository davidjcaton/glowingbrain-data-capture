namespace GlowingBrain.DataCapture.ViewModels
{
	public interface INavigateBackResult : IResult
	{
	}

	public interface ISubmitPageResult : IResult
	{
	}

	public class SuccessSubmitPageResult : ISubmitPageResult
	{
		public bool IsSuccess {
			get { return true; }
		}
	}

	public class ValidationFailureSubmitPageResult : ISubmitPageResult
	{
		public bool IsSuccess {
			get { return false; }
		}
	}

	public class SuccessNavigateBackResult : INavigateBackResult
	{
		public bool IsSuccess {
			get { return true; }
		}
	}

	public class FailureNavigateBackResult : INavigateBackResult
	{
		public bool IsSuccess {
			get { return false; }
		}
	}
}
