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

		public SurveyPageItemsView () : this (SurveyPageAppearance.Default)
		{
		}

		public SurveyPageItemsView (SurveyPageAppearance appearance)
		{
			_appearance = appearance;

			VerticalOptions = LayoutOptions.FillAndExpand;

			Style = appearance.PageItemsViewStyle;

			_stackLayout = new StackLayout {
				Style = appearance.PageItemsLayoutStyle
			};
				
			var scrollView = new ScrollView ();
			scrollView.Content = _stackLayout;

			Content = scrollView;
		}

		public SurveyPageAppearance Appearance {
			get { return _appearance; }
		}

		public static readonly BindableProperty ItemsProperty = BindableProperty.Create<SurveyPageItemsView, IList<ISurveyItem>> (
			p => p.Items,
			new List<ISurveyItem> (),
			BindingMode.OneWay,
			propertyChanged: OnQuestionsChanged);

		public IList<ISurveyItem> Items {
			get { return (IList<ISurveyItem>)GetValue (ItemsProperty); }
			set { SetValue (ItemsProperty, value); }
		}

		protected virtual void OnQuestionsChanged (IList<ISurveyItem> oldValue, IList<ISurveyItem> newValue)
		{
			_stackLayout.Children.Clear ();

			if (newValue != null) {
				BuildQuestions (newValue);
			}
		}

		protected virtual void BuildQuestions (IList<ISurveyItem> questions)
		{
			foreach (var question in questions) {
				var questionView = BuildSectionForQuestion (question, _appearance);
				_stackLayout.Children.Add (questionView);
			}
		}

		protected virtual View BuildSectionForQuestion (ISurveyItem question, SurveyPageAppearance appearance)
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
			inputStackLayout.Children.Add (StandardViews.CreateSeparator (appearance.SeperatorStyle));
			var inputView = QuestionViews.ViewForQuestion (question, appearance);
			inputStackLayout.Children.Add (inputView);
			inputStackLayout.Children.Add (StandardViews.CreateSeparator (appearance.SeperatorStyle));

			if (!String.IsNullOrWhiteSpace (question.Footnote)) {
				var footerView = new QuestionFooterView (question, appearance);
				stackLayout.Children.Add (footerView);
			}

			return stackLayout;
		}

		static void OnQuestionsChanged (BindableObject bindable, IList<ISurveyItem> oldValue, IList<ISurveyItem> newValue)
		{
			((SurveyPageItemsView)bindable).OnQuestionsChanged (oldValue, newValue);
		}
	}
	
}
