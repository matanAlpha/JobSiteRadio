using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JobSiteRadio
{
	public class MediaPlayerViewModel
	{

		public ICommand PlayCommand { get; private set; }
		public ICommand ForwardCommand { get; private set; }
		public ICommand BackwordCommand { get; private set; }
		public ICommand PauseCommand { get; private set; }
		public ICommand NowPlayingCommand { get; private set; }

		Action playTask = () =>
		{
			var mediaPlayer = DependencyService.Get<IMediaPlayer>();
			if (mediaPlayer != null)
			{
				mediaPlayer.Play();
			}
		};
		Action forwardTask = () =>
		{
			var mediaPlayer = DependencyService.Get<IMediaPlayer>();
			if (mediaPlayer != null)
			{
				mediaPlayer.Forward();
			}
		};

		Action backwardTask = () =>
		{
			var mediaPlayer = DependencyService.Get<IMediaPlayer>();
			if (mediaPlayer != null)
			{
				mediaPlayer.Backward();
			}
		};
		Action pauseTask = () =>
			{
				var mediaPlayer = DependencyService.Get<IMediaPlayer>();
				if (mediaPlayer != null)
				{
					mediaPlayer.Pause();
				}
			};
		Action getNowPlayingTask = () =>
		{
			var mediaPlayer = DependencyService.Get<IMediaPlayer>();
			if (mediaPlayer != null)
			{
				var nowPlayingData  = mediaPlayer.getNowPlaying();

			};
		};
		public MediaPlayerViewModel()
		{
			PlayCommand =  new Command( async () => await CodeRunnerTask(playTask));
			ForwardCommand =  new Command(async () => await CodeRunnerTask(forwardTask));
			BackwordCommand =  new Command(async () => await CodeRunnerTask(backwardTask));
			PauseCommand =  new Command(async () => await CodeRunnerTask(pauseTask));
		
			
		}

	
		public string NowPlayingTitle { get; set; } = "Now we are playing Titel";
		public string NowPlayingArtist { get; set; } = "Now we are playing Artis";
		public string NowPlayingTime { get; set; } = "Now we are playing Time";
	


async Task RunNowPlayingTask()
{
	await Task.Run(() =>
	{

		var mediaPlayer = DependencyService.Get<IMediaPlayer>();
		if (mediaPlayer != null)
		{
			NowPlayingData nowPlayingData = mediaPlayer.getNowPlaying();
			NowPlayingTitle = nowPlayingData.Title;
		};
	});
}


		async Task  CodeRunnerTask(Action codeToRun)
		{
			await Task.Run(codeToRun);

		}
	}
}
