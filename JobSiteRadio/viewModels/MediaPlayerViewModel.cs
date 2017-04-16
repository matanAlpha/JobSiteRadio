using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JobSiteRadio
{
    public class MediaPlayerViewModel : INotifyPropertyChanged
    {
        private const int START_VOLUME = 50;
        private const int MAX_VOLUME = 100;

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

		public MediaPlayerPage page;

		MemoryStream imageMemoryStream = null;

        public void viewAppeared()
        {
            IsViewVisible = true;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        {

            var mediaPlayer = DependencyService.Get<IMediaPlayer>();
            if (mediaPlayer != null)
            {
                NowPlayingData nowPlayingData = mediaPlayer.getNowPlaying();

                NowPlayingTitle = nowPlayingData.Title;
                NowPlayingArtist = nowPlayingData.Artist;
                NowPlayingTime = ConvertTime(nowPlayingData.CurrentPlaybackTime);
                decimal currentVolume = new decimal(nowPlayingData.Volume * MAX_VOLUME);
                updateVolume(currentVolume);
                NowPlayingDuration = ConvertTime(nowPlayingData.PlaybackDuration);
                ProgressPercent = Math.Floor(100 * (nowPlayingData.CurrentPlaybackTime / nowPlayingData.PlaybackDuration)).ToString();
				if

						(nowPlayingData.ArtWork != null && page.getNowPLayingImage()!=null) 
				{ 
imageMemoryStream	= nowPlayingData.ArtWork;
					OnPropertyChanged("ArtworkImageStream");
					//page.getNowPLayingImage().Source = ImageSource.FromStream(() => nowPlayingData.ArtWork); 
	
					}
						

            };
            Debug.WriteLine("Timer tick");
            return IsViewVisible;
        });

        }

        public void viewDisappeared()
        {
            IsViewVisible = false;
        }

        public MediaPlayerViewModel()
        {
            PlayCommand = new Command(() =>
            {
                playButtonVisible = false;
                updateButtonsVisability();
                playTask.Invoke();
            });
            ForwardCommand = new Command(async () => await CodeRunnerTask(forwardTask));
            BackwordCommand = new Command(async () => await CodeRunnerTask(backwardTask));
            PauseCommand = new Command(() =>
            {
                playButtonVisible = true;
                updateButtonsVisability();
                pauseTask.Invoke();
            });
            NowPlayingCommand = new Command(async () => await RunNowPlayingTask());

            //var mediaPlayer = DependencyService.Get<IMediaPlayer>();
            //if (mediaPlayer != null)
            //{
            //    mediaPlayer.setNowPlayingCallback(this);

            //};

        }

        private void updateButtonsVisability()
        {
            OnPropertyChanged("IsPlayButtonVisible");
            OnPropertyChanged("IsPauseButtonVisible");
        }

        private decimal _volumeValue = START_VOLUME;
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
                    setVolume(_volumeValue);
                    OnPropertyChangedSelf();
                }
            }
        }

        private void setVolume(decimal volume)
        {
            var mediaPlayer = DependencyService.Get<IMediaPlayer>();
            if (mediaPlayer != null)
            {
                mediaPlayer.SetVolume(((float)(_volumeValue / MAX_VOLUME)));
            }
        }

        private void updateVolume(decimal volume)
        {
            _volumeValue = volume;
            OnPropertyChanged("VolumeValue");

        }


        private string ConvertTime(double miliSeconds)
        {
            var timeSpan = TimeSpan.FromSeconds(miliSeconds);
            // Converts the total miliseconds to the human readable time format
            return timeSpan.ToString(@"mm\:ss");
        }



        async Task RunNowPlayingTask()
        {
            await Task.Run(() =>
            {
                var mediaPlayer = DependencyService.Get<IMediaPlayer>();
                if (mediaPlayer != null)
                {
                    NowPlayingData nowPlayingData = mediaPlayer.getNowPlaying();
                    NowPlayingTitle = nowPlayingData.Title;
                    NowPlayingArtist = nowPlayingData.Artist;
                    NowPlayingTime = ConvertTime(nowPlayingData.CurrentPlaybackTime);
                    NowPlayingDuration = ConvertTime(nowPlayingData.PlaybackDuration);
                    decimal currentVolume = new decimal(nowPlayingData.Volume * MAX_VOLUME);
                    updateVolume(currentVolume);
                    ProgressPercent = Math.Floor(100 * (nowPlayingData.CurrentPlaybackTime / nowPlayingData.PlaybackDuration)).ToString();
                };
            });
        }


        bool playButtonVisible = true;

        public bool IsPauseButtonVisible { get { return !playButtonVisible; } }
        public bool IsPlayButtonVisible { get { return playButtonVisible; } }
        public bool IsViewVisible { get; set; }


        public string _nowPlayingTitle = "Now we are playing Titel";
        public string _nowPlayingArtist = "Now we are playing Artis";
        public string _nowPlayingTime = "Now we are playing Time";
        public string _nowPlayingDuration = "12:20";



public Stream ArtworkImageStream
		{
			get { return imageMemoryStream; }
		}


        public string NowPlayingTitle
        {
            get
            {
                return _nowPlayingTitle;
            }
            set
            {
                if (_nowPlayingTitle != value)
                {
                    _nowPlayingTitle = value;
                    OnPropertyChangedSelf();
                }
            }
        }

        public string NowPlayingArtist
        {
            get
            {
                return _nowPlayingArtist;
            }
            set
            {
                if (_nowPlayingArtist != value)
                {
                    _nowPlayingArtist = value;
                    OnPropertyChangedSelf();
                }
            }
        }

        public string NowPlayingTime
        {
            get
            {
                return _nowPlayingTime;
            }
            set
            {
                if (_nowPlayingTime != value)
                {
                    _nowPlayingTime = value;
                    OnPropertyChangedSelf();
                }
            }
        }

        public string NowPlayingDuration
        {
            get
            {
                return _nowPlayingDuration;
            }
            set
            {
                if (_nowPlayingDuration != value)
                {
                    _nowPlayingDuration = value;
                    OnPropertyChangedSelf();
                }
            }
        }

   

        async Task CodeRunnerTask(Action codeToRun)
        {
            await Task.Run(codeToRun);
        }

        private double _progressPercent;
        public string ProgressPercent
        {
            get { return _progressPercent.ToString(); }
            set
            {
                double doubleValue;
                double.TryParse(value, out doubleValue);

                if (_progressPercent == doubleValue) return;

                _progressPercent = Math.Max(0, Math.Min(doubleValue, 100));

                Progress = _progressPercent / 100;

                OnPropertyChanged("Progress");
            }
        }

        public double Progress { get; private set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void OnPropertyChangedSelf(
       [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
