using System;
using JobSiteRadio.iOS;
using MediaPlayer;
using Xamarin.Forms;


[assembly: Dependency(typeof(MediaPlayerImpl))]
namespace JobSiteRadio.iOS
{
	
	public class MediaPlayerImpl : IMediaPlayer
	{
		public MediaPlayerImpl()
		{
		}

		public void Backward()
		{
			MPMusicPlayerController.SystemMusicPlayer.SkipToPreviousItem();
		}

		public void Forward()
		{
			MPMusicPlayerController.SystemMusicPlayer.SkipToNextItem();
		}

		public NowPlayingData getNowPlaying()
		{
			var ret = new NowPlayingData();
			ret.Title = MPMusicPlayerController.SystemMusicPlayer.NowPlayingItem?.Title;
			return ret;

		}

		public void Pause()
		{
			MPMusicPlayerController.SystemMusicPlayer.Pause();
		}

		public void Play()
		{
			MPMusicPlayerController.SystemMusicPlayer.Play();
		}
	}
}
