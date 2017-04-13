using System;
namespace JobSiteRadio
{
	public interface IMediaPlayer
	{
		void Play();
		void Forward();
		void Backward();
		void Pause();
		void SetVolume(float volume);
		void setNowPlayingCallback(MediaPlayerViewModel vm);
		NowPlayingData getNowPlaying();
	}
}
