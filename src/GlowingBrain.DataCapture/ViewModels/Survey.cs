using System.Collections.Generic;

namespace GlowingBrain.DataCapture.ViewModels
{
	public class Survey : PropertyChangedBase, ISurvey
	{
		string _title;
		double _progress;
		List<SurveyPage> _pages;
		int _currentPageIndex = -1;

		public Survey ()
		{
			_pages = new List<SurveyPage> ();
			_progress = 0.0;
			CurrentPageIndex = 0;
		}

		public string Title {
			get { return _title; }
			set { Set (ref _title, value); }
		}

		public double Progress {
			get { return _progress; }
			set { Set (ref _progress, value); }
		}

		public ISurveyPage CurrentPage {
			get { 
				var page = CurrentPageIndex < _pages.Count ? _pages [CurrentPageIndex] : null; 
				if (page != null) {
					page.IsFirstPage = (CurrentPageIndex == 0);
					page.IsLastPage = (CurrentPageIndex == _pages.Count - 1);
				}
				return page;
			}
		}

		public List<SurveyPage> Pages {
			get { return _pages; }
			set { Set (ref _pages, value); }
		}

		public ISubmitPageResult SubmitPage (IEnumerable<IQuestion> questions)
		{
			foreach (var question in questions) {
				question.Validate ();
				if (question.HasError) {
					return new ValidationFailureSubmitPageResult ();
				}
			}

			OnAdvancePage ();
			return new SuccessSubmitPageResult ();
		}

		public INavigateBackResult NavigateBack ()
		{
			if (CurrentPageIndex == 0) {
				return new FailureNavigateBackResult ();
			}

			OnBackPage ();
			return new SuccessNavigateBackResult ();
		}

		protected virtual void OnAdvancePage ()
		{
			CurrentPageIndex++;
		}

		protected virtual void OnBackPage ()
		{
			CurrentPageIndex--;
		}

		private int CurrentPageIndex {
			get { return _currentPageIndex; }
			set {
				if (Set (ref _currentPageIndex, value)) {
					NotifyPropertyChanged ("CurrentPage");
					Progress = _pages.Count == 0 ? 0.0 : ((double)CurrentPageIndex / _pages.Count);
				}
			}
		}
	}
}
