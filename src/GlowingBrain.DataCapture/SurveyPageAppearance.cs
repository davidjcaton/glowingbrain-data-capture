using System;
using Xamarin.Forms;
using GlowingBrain.DataCapture.Views;

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
			SelectedOptionImageSource = ImageSource.FromFile ("tick.png");
			UnselectedOptionImageSource = ImageSource.FromFile ("empty.png");
			FooterFontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
			SelectedCheckboxImageSource = ImageSource.FromFile ("tick.png");
			UnselectedCheckboxImageSource = ImageSource.FromFile ("empty.png");
			DisclosureImageSource = ImageSource.FromFile ("disclosure.png");

			PageItemsViewStyle = new Style (typeof(StackLayout)) {
				Setters = {
					new Setter {
						Property = StackLayout.SpacingProperty,
						Value = 25
					}
				}
			};

			QuestionInputViewStyle = new Style (typeof (VisualElement)) {
				Setters = {
					new Setter {
						Property = VisualElement.HeightRequestProperty,
						Value = 50
					}
				}
			};

			QuestionOptionStyle = new Style (typeof(Option)) {
				BasedOn = QuestionInputViewStyle
			};
		
			QuestionInputViewContainerLayoutStyle = new Style (typeof(StackLayout)) {
				Setters = {
					new Setter {
						Property = StackLayout.PaddingProperty,
						Value = new Thickness (10, 0, 10, 0)
					}
				}
			};

			QuestionErrorLabelStyle = new Style (typeof(Label)) {
				Setters = {
					new Setter {
						Property = Label.TextColorProperty,
						Value = Color.Red
					},
					new Setter {
						Property = Label.FontAttributesProperty,
						Value = FontAttributes.Italic
					}
				}
			};
		}

		public static SurveyPageAppearance Default { get; set; }

		public Color BackgroundColor { get; set; }
		public Color SeparatorColor { get; set; }
		public double FooterFontSize { get; set; }
		public double HeaderHeight { get; set; }

		public ImageSource SelectedOptionImageSource { get; set; }

		public ImageSource UnselectedOptionImageSource { get; set; }

		public ImageSource SelectedCheckboxImageSource { get; set; }

		public ImageSource UnselectedCheckboxImageSource { get; set; }

		public ImageSource DisclosureImageSource { get; set; }

		public Style PageItemsViewStyle { get; set; }

		public Style QuestionInputViewStyle { get; set; }

		public Style QuestionOptionStyle { get; set; }

		public Style QuestionInputViewContainerLayoutStyle { get; set; }

		public Style QuestionErrorLabelStyle { get; set; }
	}		
}
