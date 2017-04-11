using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace dotnetTurtle.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel()
		{
			Title = ".NETBC";

            var logoImage = new Image { Aspect = Aspect.AspectFit };
            logoImage.Source = ImageSource.FromFile("dotnetbclogo.png");

            OpenWebCommand = new Command(() =>
                Device.OpenUri(new Uri("http://dotnetbcfrontend.azurewebsites.net/")));
		}

		/// <summary>
		/// Command to open browser to xamarin.com
		/// </summary>
		public ICommand OpenWebCommand { get; }
	}
}
