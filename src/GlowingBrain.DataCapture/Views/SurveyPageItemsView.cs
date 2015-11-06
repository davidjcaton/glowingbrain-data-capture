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

		protected virtual void BuildQuestions (IList<ISurveyItem> items)
		{
			foreach (var item in items) {
				var questionView = BuildItem (item, _appearance);
				_stackLayout.Children.Add (questionView);
			}
		}

		protected virtual View BuildItem (ISurveyItem item, SurveyPageAppearance appearance)
		{
			var wrapInContainer = !(item is IStaticSurveyItem);
			return SurveyItemViewFactory.Default.CreateViewForItem (item, appearance, wrapInContainer);
		}

		static void OnQuestionsChanged (BindableObject bindable, IList<ISurveyItem> oldValue, IList<ISurveyItem> newValue)
		{
			((SurveyPageItemsView)bindable).OnQuestionsChanged (oldValue, newValue);
		}
	}	
}
