using System;
using JobSiteRadio.Droid;
using Xamarin.Forms;


[assembly: Dependency(typeof(MediaPlayerImpl))]
namespace JobSiteRadio.Droid
{
	
	public class MediaPlayerImpl : IMediaPlayer
	{
		public MediaPlayerImpl()
		{
		}

		public void Backward()
		{
			
		}

		public void Forward()
		{
			
		}

		public NowPlayingData getNowPlaying()
		{
			var ret = new NowPlayingData();
			return ret;

		}

		public void Pause()
		{
		}

		public void Play()
		{
		}
	}
}
