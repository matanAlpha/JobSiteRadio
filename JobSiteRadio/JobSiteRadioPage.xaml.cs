using System;
using Xamarin.Forms;

namespace JobSiteRadio
{
	public partial class JobSiteRadioPage : ContentPage
	{
		public JobSiteRadioPage()
		{
			InitializeComponent();
		}

		async void OpenMediaPLayer(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MediaPlayerPage());
		}
	}
}
