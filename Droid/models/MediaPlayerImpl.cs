using System;
using JobSiteRadio.Droid;
using Xamarin.Forms;
using Android.Media.Session;
using Android.Media;
using System.Collections.Generic;

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

		public void SetVolume(float volume)
		{
			throw new NotImplementedException();
		}

		public void Play()
		{
List<MediaSession.QueueItem> playingQueue;

			var currentContext = Forms.Context;
			MediaSession session = new MediaSession(currentContext, "mySession");
			var mediaControler = session.Controller;
			var meta = mediaControler.Metadata;
			var pbIn = mediaControler.GetPlaybackInfo();



						playingQueue = new List<MediaSession.QueueItem> ();

			var tt = session.SessionToken;
			var qu = mediaControler.Queue;


var mediaCallback = new MediaSessionCallback();

mediaCallback.OnPlayImpl = () => {
				//LogHelper.Debug (Tag, "play");

				//if (playingQueue == null || playingQueue.Count != 0) {
				//	playingQueue = new List<MediaSession.QueueItem> (QueueHelper.GetRandomQueue (musicProvider));
				//	session.SetQueue (playingQueue);
				//	session.SetQueueTitle (GetString(Resource.String.random_queue_title));
				//	//currentIndexOnQueue = 0;
				//}

				//if (playingQueue != null && playingQueue.Count != 0) {
				//	HandlePlayRequest();
				//}
			};
		mediaControler.SetVolumeTo(10, AudioFlags.AudibilityEnforced);
		}





class MediaSessionCallback : MediaSession.Callback
{
	public Action OnPlayImpl { get; set; }

	public Action<long> OnSkipToQueueItemImpl { get; set; }

	public Action<long> OnSeekToImpl { get; set; }

	public Action<string, Android.OS.Bundle> OnPlayFromMediaIdImpl { get; set; }

	public Action OnPauseImpl { get; set; }

	public Action OnStopImpl { get; set; }

	public Action OnSkipToNextImpl { get; set; }

	public Action OnSkipToPreviousImpl { get; set; }

	public Action<string, Android.OS.Bundle> OnCustomActionImpl { get; set; }

	public Action<string, Android.OS.Bundle> OnPlayFromSearchImpl { get; set; }

	public override void OnPlay()
	{
		OnPlayImpl();
	}

	public override void OnSkipToQueueItem(long id)
	{
		OnSkipToQueueItemImpl(id);
	}

	public override void OnSeekTo(long pos)
	{
		OnSeekToImpl(pos);
	}

			public override void OnPlayFromMediaId(string mediaId, Android.OS.Bundle extras)
			{
				base.OnPlayFromMediaId(mediaId, extras);
			}
	//public override void OnPlayFromMediaId(string mediaId, Bundle extras)
	//{
	//	OnPlayFromMediaIdImpl(mediaId, extras);
	//}

	public override void OnPause()
	{
		OnPauseImpl();
	}

	public override void OnStop()
	{
		OnStopImpl();
	}

	public override void OnSkipToNext()
	{
		OnSkipToNextImpl();
	}

	public override void OnSkipToPrevious()
	{
		OnSkipToPreviousImpl();
	}

			public override void OnCustomAction(string action, Android.OS.Bundle extras)
			{
				base.OnCustomAction(action, extras);
		
			}

			public override void OnPlayFromSearch(string query, Android.OS.Bundle extras)
			{
				base.OnPlayFromSearch(query, extras);
			}

	//public override void OnCustomAction(string action, Bundle extras)
	//{
	//	OnCustomActionImpl(action, extras);
	//}

	//public override void OnPlayFromSearch(string query, Bundle extras)
	//{
	//	OnPlayFromSearchImpl(query, extras);
	//}
		}


	}
}
