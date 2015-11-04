using System;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture
{
	public class SurveyPageAppearance : PropertyChangedBase
	{
		static SurveyPageAppearance ()
		{
			Default = new SurveyPageAppearance ();
		}

		public SurveyPageAppearance ()
		{
			BackgroundColor = Color.FromHex ("#EBEBF2");
			SeparatorColor = Color.FromHex ("#b6b6b6");
			HeaderHeight = 50;
			ItemHeight = 40;
			QuestionSpacing = 20;
			SelectedOptionImageSource = ImageSource.FromFile ("tick.png");
			UnselectedOptionImageSource = ImageSource.FromFile ("empty.png");
			FooterFontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
			SelectedCheckboxImageSource = ImageSource.FromFile ("tick.png");
			UnselectedCheckboxImageSource = ImageSource.FromFile ("empty.png");
			DisclosureImageSource = ImageSource.FromFile ("disclosure.png");
		}

		public static SurveyPageAppearance Default { get; set; }

		public Color BackgroundColor { get; set; }
		public Color SeparatorColor { get; set; }
		public double ItemHeight { get; set; }
		public double HeaderHeight { get; set; }
		public double QuestionSpacing { get; set; }
		public ImageSource SelectedOptionImageSource { get; set; }
		public ImageSource UnselectedOptionImageSource { get; set; }
		public double FooterFontSize { get; set; }
		public ImageSource SelectedCheckboxImageSource { get; set; }
		public ImageSource UnselectedCheckboxImageSource { get; set; }
		public ImageSource DisclosureImageSource { get; set; }
	}		
}
