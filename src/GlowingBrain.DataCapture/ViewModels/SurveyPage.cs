using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace GlowingBrain.DataCapture.ViewModels
{
	public class SurveyPage : ContainerSurveyItem, ISurveyPage
	{
		readonly ISurvey _survey;
		readonly DelegateCommand _navigateBackCommand;
		readonly DelegateCommand _submitPageCommand;

		public SurveyPage (ISurvey survey) : base (null)
		{
			_survey = survey;

			_navigateBackCommand = new DelegateCommand (
				_ => OnNavigateBack (),
				_ => OnCanExecuteNavigateBack ());
			
			_submitPageCommand = new DelegateCommand (
				_ => OnSubmitPage (),
				_ => OnCanExecuteSubmitPage ());
		}

		public ISurvey Survey {
			get { return _survey; }
		}

		public bool IsFirstPage {
			get;
			set;
		}

		public bool IsLastPage {
			get;
			set;
		}

		public ICommand NavigateBack {
			get { return _navigateBackCommand; }
		}

		public ICommand SubmitPage {
			get { return _submitPageCommand; }
		}

		protected virtual void OnSubmitPage ()
		{			
			_survey.SubmitPage (Questions);
		}

		protected virtual bool OnCanExecuteSubmitPage ()
		{
			// find all mandatory questions
			var mandatoryQuestions = this.Questions.Where (q => q.IsMandatory);

			// check all have responses
			var allMandatoryQuestionsHaveResponses = mandatoryQuestions.All (q => q.HasResponse);

			return allMandatoryQuestionsHaveResponses;
		}

		protected virtual void OnNavigateBack ()
		{
			_survey.NavigateBack ();
		}

		protected virtual bool OnCanExecuteNavigateBack ()
		{
			return !IsFirstPage;
		}

		protected IEnumerable<IQuestion> Questions {
			get { return this.Descendants ().OfType<IQuestion> (); }
		}

		protected override void OnChildResponseChanged (ISurveyItem item)
		{
			base.OnChildResponseChanged (item);
			_submitPageCommand.RaiseCanExecuteChanged ();
		}
	}
}
