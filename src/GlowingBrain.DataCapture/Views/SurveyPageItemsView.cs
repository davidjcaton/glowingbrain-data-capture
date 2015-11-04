using System;
using System.Collections.Generic;
using GlowingBrain.DataCapture.ViewModels;
using GlowingBrain.DataCapture.Views.Questions;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views
{
	public class SurveyPageItemsView : ContentView
	{
		readonly StackLayout _stackLayout;
		readonly SurveyPageAppearance _appearance;

		public SurveyPageItemsView () : this (null)
		{
		}

		public SurveyPageItemsView (SurveyPageAppearance appearance)
		{
			_appearance = appearance ?? SurveyPageAppearance.Default;

			BackgroundColor = _appearance.BackgroundColor;
			VerticalOptions = LayoutOptions.FillAndExpand;

			_stackLayout = new StackLayout ();
			_stackLayout.Spacing = _appearance.QuestionSpacing;

			var scrollView = new ScrollView ();
			scrollView.Content = _stackLayout;

			Content = scrollView;
		}

		public SurveyPageAppearance Appearance {
			get { return _appearance; }
		}

		public static readonly BindableProperty ItemsProperty = BindableProperty.Create<SurveyPageItemsView, IList<SurveyItem>> (
			p => p.Items,
			new List<SurveyItem> (),
			BindingMode.OneWay,
			propertyChanged: OnQuestionsChanged);

		public IList<SurveyItem> Items {
			get { return (IList<SurveyItem>)GetValue (ItemsProperty); }
			set { SetValue (ItemsProperty, value); }
		}

		protected virtual void OnQuestionsChanged (IList<SurveyItem> oldValue, IList<SurveyItem> newValue)
		{
			_stackLayout.Children.Clear ();

			if (newValue != null) {
				BuildQuestions (newValue);
			}
		}

		protected virtual void BuildQuestions (IList<SurveyItem> questions)
		{
			foreach (var question in questions) {
				var questionView = BuildSectionForQuestion (question, _appearance);
				_stackLayout.Children.Add (questionView);
			}
		}

		protected virtual View BuildSectionForQuestion (SurveyItem question, SurveyPageAppearance appearance)
		{
			var stackLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			var headerView = new QuestionHeaderView (question, appearance);
			headerView.VerticalOptions = LayoutOptions.Start;

			stackLayout.Children.Add (headerView);

			var inputStackLayout = new StackLayout ();
			stackLayout.Children.Add (inputStackLayout);

			inputStackLayout.BackgroundColor = Color.White;
			inputStackLayout.Children.Add (StandardViews.CreateSeparator (appearance.SeparatorColor));
			var inputView = QuestionViews.ViewForQuestion (question, appearance);
			inputStackLayout.Children.Add (inputView);
			inputStackLayout.Children.Add (StandardViews.CreateSeparator (appearance.SeparatorColor));

			if (!String.IsNullOrWhiteSpace (question.Footnote)) {
				var footerView = new QuestionFooterView (question, appearance);
				stackLayout.Children.Add (footerView);
			}

			return stackLayout;
		}

		static void OnQuestionsChanged (BindableObject bindable, IList<SurveyItem> oldValue, IList<SurveyItem> newValue)
		{
			((SurveyPageItemsView)bindable).OnQuestionsChanged (oldValue, newValue);
		}
	}
	
}
