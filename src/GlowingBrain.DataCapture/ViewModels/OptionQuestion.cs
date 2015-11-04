using System;
using System.Collections.Generic;
using System.Linq;

namespace GlowingBrain.DataCapture.ViewModels
{
	public abstract class OptionQuestion : Question<string>
	{
		OptionValue _selectedOption;
		List<OptionValue> _optionValues = new List<OptionValue> ();

		protected OptionQuestion (ISurveyPage page) : base (page)
		{
		}

		public override bool HasResponse {
			get { return !String.IsNullOrEmpty (Response); }
		}

		public List<OptionValue> OptionValues { 
			get { return _optionValues; }
			set {
				if (Set (ref _optionValues, value)) {
					OnOptionValuesChanged ();
				}
			}
		}

		public OptionValue SelectedOption {
			get { return _selectedOption; }
			set {
				if (Set (ref _selectedOption, value)) {
					OnSelectedOptionChanged ();
				}
			}
		}

		protected override void OnResponseChanged ()
		{
			base.OnResponseChanged ();
			SetSelectedOption ();
		}

		void OnSelectedOptionChanged ()
		{
			if (SelectedOption != null) {
				Response = SelectedOption.Value;
			}
		}

		void OnOptionValuesChanged ()
		{
			SetSelectedOption ();
		}

		void SetSelectedOption ()
		{
			if (Response != null && OptionValues != null) {
				SelectedOption = OptionValues.FirstOrDefault (x => x.Value == Response);
			}
		}
	}	
}
