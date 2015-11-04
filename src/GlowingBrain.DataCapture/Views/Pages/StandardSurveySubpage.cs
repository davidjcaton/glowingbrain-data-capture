using System;
using Xamarin.Forms;
using GlowingBrain.DataCapture.ViewModels;

namespace GlowingBrain.DataCapture.Views.Pages
{
	public class StandardSurveySubpage : StandardSurveyPageBase
	{
		public StandardSurveySubpage ()
		{
			Content = new StackLayout {
				Children = {					
					OnCreatePageItemsView ()
				}
			};
		}
	}
}

