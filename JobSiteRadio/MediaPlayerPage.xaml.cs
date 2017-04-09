using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JobSiteRadio
{
	public partial class MediaPlayerPage : ContentPage
	{
		public MediaPlayerPage()
		{
			InitializeComponent();
			BindingContext = new MediaPlayerViewModel();
		}
	}
}
