using System;
namespace JobSiteRadio
{
	public class NowPlayingData
	{
		public NowPlayingData()
		{
		}

		public string Title {get;set;}
		public string Artist { get; set;}
        public string AlbumTitle { get; set; }
        public float Volume { get; set; }
        public double PlaybackDuration { get; set; }
        public double CurrentPlaybackTime { get; set; }
        
    }
}
