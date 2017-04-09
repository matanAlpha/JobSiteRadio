using System;
namespace JobSiteRadio
{
	public interface IMediaPlayer
	{
		void Play();
		void Forward();
		void Backward();
		void Pause();
	}
}
