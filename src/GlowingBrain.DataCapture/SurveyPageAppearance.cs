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
			SeperatorStyle = new Style (typeof(BoxView)) {
				Setters = {
					new Setter {
						Property = BoxView.HeightRequestProperty,
						Value = 1
					},
					new Setter {
						Property = BoxView.ColorProperty,
						Value = Color.FromHex ("#b6b6b6")
					}
				}
			};
				
			SelectedOptionImageSource = ImageSource.FromFile ("tick.png");
			UnselectedOptionImageSource = ImageSource.FromFile ("empty.png");

			SelectedCheckboxImageSource = ImageSource.FromFile ("tick.png");
			UnselectedCheckboxImageSource = ImageSource.FromFile ("empty.png");
			DisclosureImageSource = ImageSource.FromFile ("disclosure.png");

			PageItemsViewStyle = new Style (typeof(ContentView)) {
				Setters = {
					new Setter {
						Property = ContentView.BackgroundColorProperty,
						Value = Color.FromHex ("#EBEBF2")
					}
				}
			};

			PageItemsLayoutStyle = new Style (typeof(StackLayout)) {
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

			QuestionHeaderLabelStyle = new Style (typeof(Label)) {
				Setters = {
					new Setter {
						Property = Label.FontSizeProperty,
						Value = Device.GetNamedSize (NamedSize.Medium, typeof (Label))
					},
					new Setter {
						Property = Label.FontAttributesProperty,
						Value = FontAttributes.Bold
					},
					new Setter {
						Property = Label.YAlignProperty,
						Value = TextAlignment.End
					}
				}
			};

			QuestionFooterLabelStyle = new Style (typeof(Label)) {
				Setters = {
					new Setter {
						Property = Label.FontSizeProperty,
						Value = Device.GetNamedSize (NamedSize.Micro, typeof (Label))
					}
				}
			};

			QuestionHeaderLayoutStyle = new Style (typeof(StackLayout)) {
				Setters = {
					new Setter {
						Property = StackLayout.PaddingProperty,
						Value = new Thickness (10, 0, 10, 0)
					},
					new Setter {
						Property = StackLayout.HeightRequestProperty,
						Value = 50
					}
				}
			};

			QuestionFooterLayoutStyle = new Style (typeof(StackLayout)) {
				Setters = {
					new Setter {
						Property = StackLayout.PaddingProperty,
						Value = new Thickness (10, 0, 10, 0)
					}
				}
			};
		}

		public static SurveyPageAppearance Default { get; set; }

		//public Color BackgroundColor { get; set; }

		public Style SeperatorStyle { get; set; }

		public ImageSource SelectedOptionImageSource { get; set; }

		public ImageSource UnselectedOptionImageSource { get; set; }

		public ImageSource SelectedCheckboxImageSource { get; set; }

		public ImageSource UnselectedCheckboxImageSource { get; set; }

		public ImageSource DisclosureImageSource { get; set; }

		public Style PageItemsViewStyle { get; set; }

		public Style PageItemsLayoutStyle { get; set; }

		public Style QuestionInputViewStyle { get; set; }

		public Style QuestionOptionStyle { get; set; }

		public Style QuestionInputViewContainerLayoutStyle { get; set; }

		public Style QuestionErrorLabelStyle { get; set; }

		public Style QuestionFooterLabelStyle { get; set; }

		public Style QuestionHeaderLabelStyle { get; set; }

		public Style QuestionFooterLayoutStyle { get; set; }

		public Style QuestionHeaderLayoutStyle { get; set; }
	}		
}
