using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JobSiteRadio
{
    public partial class MediaPlayerPage : ContentPage
    {
        public MediaPlayerPage()
        {
            InitializeComponent();
            BindingContext = new MediaPlayerViewModel();
var vm = this.BindingContext as MediaPlayerViewModel;
			if (vm != null)
			{
				vm.page = this;

			}
            elapsed.SetBinding(AttachedProperties.AnimatedProgressProperty,
                                  "Progress");
			
        }

		public Image getNowPLayingImage()
		{
			return nowPlayingImage;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = this.BindingContext as MediaPlayerViewModel;
            if (vm == null)
                return;
            vm.viewAppeared();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var vm = this.BindingContext as MediaPlayerViewModel;
            if (vm == null)
                return;
            vm.viewAppeared();
        }
    }
}
