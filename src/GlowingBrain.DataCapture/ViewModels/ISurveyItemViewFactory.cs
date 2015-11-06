using Xamarin.Forms;

namespace GlowingBrain.DataCapture.ViewModels
{
	public interface ISurveyItemViewFactory
	{
		View CreateViewForItem (ISurveyItem item, SurveyPageAppearance appearance, bool wrapInContainer);
		Page CreatePageForItem (ISurveyItem item, SurveyPageAppearance appearance);
	}
}

