using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views
{
	public class LabelledSlider : ContentView
	{
		public LabelledSlider ()
		{
			Labels = new StringItemsList {
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
				
			Slider = new GBSlider {
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			Content = new StackLayout {
				Children = {
					Labels,
					Slider
				}
			};
		}

		public GBSlider Slider { get; private set; }

		public StringItemsList Labels { get; private set; }
	}	
}
