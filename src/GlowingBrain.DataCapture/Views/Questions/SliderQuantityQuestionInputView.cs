using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;
using System.Linq;

namespace GlowingBrain.DataCapture.Views.Questions
{
	public class SliderQuantityQuestionInputView : QuantityQuestionInputView
	{
		readonly Label _valueLabel;
		readonly Slider _slider;
		readonly OptionValuePicker _picker;
		readonly SliderQuantityQuestion _question;

		public SliderQuantityQuestionInputView (SliderQuantityQuestion question, SurveyPageAppearance appearance)
			: base (appearance)
		{
			_question = question;

			var vStack = new StackLayout {
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Fill
			};

			var valueStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Fill,
				IsVisible = false
			};

			if (question.IsValueVisible) {
				_valueLabel = BuildValueLabel (question);
				valueStack.Children.Add (_valueLabel);
				valueStack.IsVisible = true;
				UpdateValueLabel ();
			}

			if (question.HasUnitOptions) {
				_picker = BuildUnitPicker (question);
				valueStack.Children.Add (_picker);
				valueStack.IsVisible = true;
			}

			var sliderStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Fill
			};

			_slider = new Slider {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center
			};

			sliderStack.Children.Add (_slider);

			vStack.Children.Add (valueStack);
			vStack.Children.Add (sliderStack);

			UpdateUI ();

			// set event handlers AFTER populating
			_question.PropertyChanged += Question_PropertyChanged;
			_slider.PropertyChanged += Slider_PropertyChanged;

			if (_picker != null) {
				_picker.PropertyChanged += Picker_PropertyChanged;
			}

			HeightRequest = -1;
			Content = vStack;		
		}

		protected virtual Label BuildValueLabel (QuantityQuestion question)
		{
			var label = new Label {
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			return label;
		}

		protected void UpdateValueLabel ()
		{
			if (_valueLabel == null) {
				return;
			}

			_valueLabel.Text = _question.GetFormattedValue ();
		}

		void SetLimits ()
		{
			if (_question.Response == null) {
				return;
			}

			SetLimit (_question.Response.Unit, _question.Maximum, value => _slider.Maximum = value);
			SetLimit (_question.Response.Unit, _question.Minimum, value => _slider.Minimum = value);
		}

		void SetLimit (string targetUnitCode, ValueUnit limit, Action<double> applyAction)
		{
			if (limit == null) {
				return;
			}

			double converted;
			if (!SurveyExecutionContext.Default.TryConvertUnit (limit.Value, limit.Unit, targetUnitCode, out converted)) {
				return;
			}

			applyAction (converted);
		}

		void Slider_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Value") {
				ValueUnit response = null;
				if (_picker == null) {
					response = new ValueUnit { Value = _slider.Value };
				} else {
					var selectedUnitOptionValue = _picker.Value;
					if (selectedUnitOptionValue != null) {
						response = new ValueUnit { Value = _slider.Value, Unit = selectedUnitOptionValue.Value };
					}
				}
				_question.Response = response;
			}
		}

		void Picker_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Value") {
				// only set unit on response if unit selected and value already present
				if (_picker.Value != null && _question.Response != null) {
					var value = _question.Response.Value;
					// do we need unit conversion?
					var toUnitCode = _picker.Value.Value;
					if (_question.Response.Unit != null) {
						double converted;
						if (SurveyExecutionContext.Default.TryConvertUnit (value, _question.Response.Unit, toUnitCode, out converted)) {
							value = converted;
						}
					}

					_question.Response = new ValueUnit { Value = value, Unit = toUnitCode };
				}
			}
		}

		void Question_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Response") {
				UpdateUI ();
			}
		}

		void UpdateUI ()
		{
			UpdateValueLabel ();
			SetLimits ();

			if (_question.Response != null) {
				_slider.Value = _question.Response.Value;
				if (_picker != null) {
					_picker.Value = _question.UnitOptions.FirstOrDefault (x => x.Value == _question.Response.Unit);
				}
			}
		}
	}
	
}
