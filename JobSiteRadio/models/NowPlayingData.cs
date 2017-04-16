using System;
using System.IO;

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
		public MemoryStream ArtWork { get; set; }
		public bool IsPlaying { get; set; } = false;
        
    }
}
