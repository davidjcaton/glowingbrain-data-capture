using System;
using Xamarin.Forms;
using GlowingBrain.DataCapture.ViewModels;

namespace GlowingBrain.DataCapture.Views.Pages
{
	public abstract class StandardSurveyPageBase : ContentPage
	{
		protected View OnCreatePageItemsView ()
		{
			var pageItems = new SurveyPageItemsView {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
				
			pageItems.SetBinding (
				SurveyPageItemsView.ItemsProperty, 
				new Binding ("Children", BindingMode.OneWay));

			return pageItems;
		}
	}
	
}
