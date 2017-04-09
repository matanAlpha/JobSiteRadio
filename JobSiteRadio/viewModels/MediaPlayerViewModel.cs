using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace JobSiteRadio
{
	public class MediaPlayerViewModel
	{

		public ICommand PlayCommand { get; private set; }
		public MediaPlayerViewModel()
		{
			PlayCommand = new Command(Play);
		}

		public string NowPlaying { get; set; } = "Now we are playing";

		void Play()
		{
			var tt = "hh";
			var mediaPlayer = DependencyService.Get<IMediaPlayer>();
			if (mediaPlayer != null)
			{
				mediaPlayer.play();
			}
			//await Navigation.PushAsync(new MediaPlayerPage());
		}
	}
}
