using System;
using Xamarin.Forms;

namespace JobSiteRadio
{
	public partial class JobSiteRadioPage : ContentPage
	{
		public JobSiteRadioPage()
		{
			InitializeComponent();
			BindingContext = new JobSiteRadioViewModel(Navigation);
			var nav = Navigation;
		}


		async void OpenMediaPLayer(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MediaPlayerPage());
		}
	}
}
