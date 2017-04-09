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
		public MediaPlayerViewModel()
		{
			PlayCommand =  new Command( async () => await CodeRunnerTask(playTask));
			ForwardCommand =  new Command(async () => await CodeRunnerTask(forwardTask));
			BackwordCommand =  new Command(async () => await CodeRunnerTask(backwardTask));
		}

		//		<Button x:Name="forwardButon" Text="Forward" Command="{Binding ForwardCommand}" />
		//<Button x:Name="backwardButon" Text="Backward" Command="{Binding BackwordCommand}" />


		public string NowPlaying { get; set; } = "Now we are playing";



		async Task  CodeRunnerTask(Action codeToRun)
		{
			await Task.Run(codeToRun);

		}
	}
}
