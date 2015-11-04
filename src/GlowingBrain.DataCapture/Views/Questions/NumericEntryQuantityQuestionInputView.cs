using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;
using System.Linq;

namespace GlowingBrain.DataCapture.Views.Questions
{
	public class NumericEntryQuantityQuestionInputView : QuantityQuestionInputView
	{
		readonly QuantityQuestion _question;
		readonly GBEntry _entry;
		readonly OptionValuePicker _picker;

		public NumericEntryQuantityQuestionInputView (QuantityQuestion question, SurveyPageAppearance appearance)
			: base (appearance)
		{
			_question = question;

			var stackLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Horizontal,
				Spacing = 10
			};

			_entry = BuildValueEntry (question);
			stackLayout.Children.Add (_entry);

			if (question.HasUnitOptions) {
				_picker = BuildUnitPicker (question);
				stackLayout.Children.Add (_picker);
			}

			SetUIFromResponse ();

			// set event handlers AFTER populating
			_question.PropertyChanged += Question_PropertyChanged;

			_entry.TextChanged += Entry_TextChanged;

			if (_picker != null) {
				_picker.PropertyChanged += Picker_PropertyChanged;
			}

			Content = stackLayout;
		}

		GBEntry BuildValueEntry (QuantityQuestion question)
		{
			var entry = new GBEntry {
				Placeholder = question.Text,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Keyboard = Keyboard.Numeric
			};

			return entry;
		}

		void Question_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Response") {
				SetUIFromResponse ();
			}
		}

		void Entry_TextChanged (object sender, TextChangedEventArgs e)
		{
			ValueUnit response = null;

			var value = GetValue ();
			if (value.HasValue) {
				if (_picker == null) {
					response = new ValueUnit { Value = value.Value };
				} else {
					var selectedUnitOptionValue = _picker.Value;
					if (selectedUnitOptionValue != null) {
						response = new ValueUnit { Value = value.Value, Unit = selectedUnitOptionValue.Value };
					}
				}
			}

			_question.Response = response;
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

		void SetUIFromResponse ()
		{
			if (_question.Response == null) {
				_entry.Text = null;
			} else {
				_entry.Text = _question.Response.Value.ToString ();
				if (_picker != null) {
					_picker.Value = _question.UnitOptions.FirstOrDefault (x => x.Value == _question.Response.Unit);
				}
			}
		}

		double? GetValue ()
		{
			double converted;
			if (double.TryParse (_entry.Text, out converted)) {
				return converted;
			}

			return null;
		}
	}
	
}
