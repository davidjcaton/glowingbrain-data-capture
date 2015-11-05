using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace GlowingBrain.DataCapture.ViewModels
{

	public interface IQuestion : ISurveyItem
	{
		//string Id { get; }
		bool IsMandatory { get; set; }
		string ErrorMessage { get; set; }
		bool HasError { get; }
		bool HasResponse { get; }
		void ClearError ();
		void Validate ();
	}
	
}
