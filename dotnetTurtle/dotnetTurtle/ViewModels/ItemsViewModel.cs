using System;
using System.Diagnostics;
using System.Threading.Tasks;

using dotnetTurtle.Helpers;
using dotnetTurtle.Models;
using dotnetTurtle.Views;

using Xamarin.Forms;

namespace dotnetTurtle.ViewModels
{
	public class ItemsViewModel : BaseViewModel
	{
		public ObservableRangeCollection<Events> Items { get; set; }
		public Command LoadItemsCommand { get; set; }

		public ItemsViewModel()
		{
			Title = ".NETBC Events";
			Items = new ObservableRangeCollection<Events>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

		}

		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				Items.Clear();
				var items = await DataStore.GetItemsAsync(true);
				Items.ReplaceRange(items);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				MessagingCenter.Send(new MessagingCenterAlert
				{
					Title = "Error",
					Message = "Unable to load items.",
					Cancel = "OK"
				}, "message");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}