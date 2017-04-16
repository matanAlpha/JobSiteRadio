using System;
using System.IO;
using Xamarin.Forms;

namespace JobSiteRadio
{
	public static class AttachedProperties
	{
		public static BindableProperty AnimatedProgressProperty =
		   BindableProperty.CreateAttached("AnimatedProgress",
										   typeof(double),
										   typeof(ProgressBar),
										   0.0d,
										   BindingMode.OneWay,
										   propertyChanged: (b, o, n) =>
										   ProgressBarProgressChanged((ProgressBar)b, (double)n));

		private static void ProgressBarProgressChanged(ProgressBar progressBar, double progress)
		{
			ViewExtensions.CancelAnimations(progressBar);
			progressBar.ProgressTo((double)progress, 800, Easing.SinOut);
		}


		public static readonly BindableProperty ArtWorkImageSourceProperty =
					  BindableProperty.CreateAttached("ArtWorkImageSource",
											   typeof(MemoryStream),
													typeof(Image),
											   null,
											   BindingMode.OneWay,
											   propertyChanged: (b, o, n) =>
													ImageImageChangeChanged((Image)b, (MemoryStream)n));



		private static void ImageImageChangeChanged(Image progressBar, MemoryStream progress)
		{
			ViewExtensions.CancelAnimations(progressBar);
			progressBar.Source = ImageSource.FromStream(() => progress);
		}

	}

}
