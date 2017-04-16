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
			elapsed.SetBinding(AttachedProperties.AnimatedProgressProperty,  
                                  "Progress");
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
