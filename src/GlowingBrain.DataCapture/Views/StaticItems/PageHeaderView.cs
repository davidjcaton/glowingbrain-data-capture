using System;
using GlowingBrain.DataCapture.ViewModels;
using Xamarin.Forms;

namespace GlowingBrain.DataCapture.Views.StaticItems
{
	public class PageHeaderView : ContentView
	{
		public PageHeaderView (PageHeader header, SurveyPageAppearance appearance)
		{
			var stackLayout = new StackLayout {
				Style = appearance.PageHeaderContentLayoutStyle
			};

			if (!String.IsNullOrEmpty (header.Caption)) {
				var captionLabel = new Label { 
					Text = header.Caption,
					Style = appearance.PageHeaderCaptionLabelStyle
				};

				stackLayout.Children.Add (captionLabel);
			}

			if (!String.IsNullOrEmpty (header.Text)) {
				var textLabel = new Label {
					Text = header.Text,
					Style = appearance.PageHeaderTextLabelStyle
				};

				stackLayout.Children.Add (textLabel);
			}

			Content = new StackLayout {
				Style = appearance.PageHeaderLayoutStyle,
				Children = {
					stackLayout,
					StandardViews.CreateSeparator (appearance.PageHeaderSeperatorStyle)
				}
			};
		}
	}
}

