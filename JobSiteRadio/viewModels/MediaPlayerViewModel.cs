using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JobSiteRadio
{
	public class MediaPlayerViewModel
	{

		public ICommand PlayCommand { get; private set; }

		Action playTask = () =>
		{
			var mediaPlayer = DependencyService.Get<IMediaPlayer>();
			if (mediaPlayer != null)
			{
				mediaPlayer.play();
			}
		};
		public MediaPlayerViewModel()
		{
			PlayCommand =  new Command( async () => await CodeRunnerTask(playTask));
		}

		public string NowPlaying { get; set; } = "Now we are playing";



		async Task  CodeRunnerTask(Action codeToRun)
		{
			await Task.Run(codeToRun);

		}
	}
}
