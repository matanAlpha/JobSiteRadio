using System;
using System.IO;
using CoreGraphics;
using Foundation;
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





		// Method style
		void Callback(NSNotification notification)
		{
			Console.WriteLine("Received a notification MPMusicPlayerController", notification);
		}


		public NowPlayingData getNowPlaying()
		{
			var ret = new NowPlayingData();
			try
			{
				MPMusicPlayerController player = MPMusicPlayerController.SystemMusicPlayer;
				if (player.NowPlayingItem != null)
				{
					ret.Title = player.NowPlayingItem.Title;
                    ret.Artist = player.NowPlayingItem.Artist;
                    ret.PlaybackDuration = player.NowPlayingItem.PlaybackDuration;
                    ret.CurrentPlaybackTime = player.CurrentPlaybackTime;
                    ret.Volume = MPMusicPlayerController.SystemMusicPlayer.Volume;
					var imageBytes = GetTrackImage(player.NowPlayingItem.Artwork);
					var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Resources);
					var filePath = Path.Combine(documentsPath, "nowPlaying.png");


					NSNotificationCenter.DefaultCenter.AddObserver(
						MPMusicPlayerController.NowPlayingItemDidChangeNotification, (notification) => Callback(notification));

					MPMusicPlayerController.SystemMusicPlayer.BeginGeneratingPlaybackNotifications ();

					File.WriteAllBytes(filePath, imageBytes);
                }
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			return ret;

		}

		public byte[] GetTrackImage(MPMediaItemArtwork artWork)
		{
			var imageBytes = new byte[0];
			if (artWork != null)
			{
				if (artWork != null)
				{
					var thumb = artWork.ImageWithSize(new CGSize(100, 100));
					if (thumb != null)
					{
						return thumb.AsPNG().ToArray();
					}
				}
			}
			return imageBytes;  
		}

		public void Pause()
		{
			MPMusicPlayerController.SystemMusicPlayer.Pause();

		}

		public void Play()
		{
			
			MPMusicPlayerController.SystemMusicPlayer.Play();
            

        }

		public void SetVolume(float volume)
		{
			MPMusicPlayerController.SystemMusicPlayer.Volume = volume;
		}
	}
}
