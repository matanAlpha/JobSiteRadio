using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JobSiteRadio
{
	public class MediaPlayerViewModel : INotifyPropertyChanged
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
			PlayCommand = new Command(()=> {
				playButtonVisible = false;
                OnPropertyChanged("IsPlayButtonVisible");
                OnPropertyChanged("IsPauseButtonVisible");
				playTask.Invoke();
			});
			ForwardCommand =  new Command(async () => await CodeRunnerTask(forwardTask));
			BackwordCommand =  new Command(async () => await CodeRunnerTask(backwardTask));
			PauseCommand = new Command(() => {
				playButtonVisible = true;

				OnPropertyChanged("IsPlayButtonVisible");

				OnPropertyChanged("IsPauseButtonVisible");
				pauseTask.Invoke();
			});
		
			NowPlayingCommand =  new Command(async () => await RunNowPlayingTask());
		}


		private decimal _volumeValue = 50;
		public decimal VolumeValue
		{
			get
			{
				return _volumeValue;
			}
			set
			{
				if (_volumeValue != value)
				{
					_volumeValue = value;
					OnPropertyChanged("VolumeValue");
				}
			}
		}

public event PropertyChangedEventHandler PropertyChanged;
protected virtual void OnPropertyChanged(string propertyName)
{
	var changed = PropertyChanged;
	if (changed != null)
	{
		PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
	}
	}

		bool playButtonVisible = true;

		public bool IsPauseButtonVisible { get { return !playButtonVisible;} } 
		public bool IsPlayButtonVisible { get { return playButtonVisible;} } 

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

async Task RunPlayPauseTask(bool runPLay)
{
	await Task.Run(() =>
	{

		var mediaPlayer = DependencyService.Get<IMediaPlayer>();
		if (mediaPlayer != null)
		{
			if (runPLay)
			{
				playButtonVisible = false;
						mediaPlayer.Play();

			}
			else
			{
						playButtonVisible = true;
						mediaPlayer.Pause();
			}
		};
	});
}



		async Task  CodeRunnerTask(Action codeToRun)
		{
			await Task.Run(codeToRun);

		}
	}
}
