using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace JobSiteRadio
{
	public class JobSiteRadioViewModel
	{

		public INavigation myNavigation { get; set; }
		public ICommand OpemMediaPlayerCommand { get; private set; }
		public JobSiteRadioViewModel(INavigation navigation)
		{
			OpemMediaPlayerCommand = new Command(openMediaPlayer);
			myNavigation = navigation;
		}


		async public void openMediaPlayer()
		{
			await myNavigation.PushAsync(new MediaPlayerPage());
		}
	}
}
