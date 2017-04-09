using JobSiteRadio.iOS;
using MediaPlayer;
using Xamarin.Forms;


[assembly: Dependency(typeof(MediaPlayerImple))]
namespace JobSiteRadio.iOS
{
	
	public class MediaPlayerImple : IMediaPlayer
	{
		public MediaPlayerImple()
		{
		}

		public void play()
		{
			MPMusicPlayerController.SystemMusicPlayer.Play();
		}
	}
}
