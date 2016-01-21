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

		/// <summary>
		/// Called prior to page submission to ensure the underlying 
		/// response store has the current user response. This is important
		/// for certain queation types (such as booleans) that have an
		/// implicit default value that must be committed even if the
		/// user has not interacted with the UI elements
		/// </summary>
		void Commit ();
	}
}
