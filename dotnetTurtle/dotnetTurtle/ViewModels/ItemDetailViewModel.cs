using dotnetTurtle.Models;
using Xamarin.Forms;

namespace dotnetTurtle.ViewModels
{
	public class ItemDetailViewModel : BaseViewModel
	{
        public Events Item { get; set; }
        public string Html { get; set; }

        public string date { get; set; }


        public ItemDetailViewModel(Events events = null) {
            Title = events.evbrief;
            Item = events;
            
            date = events.evdate + " " + events.evday + " @ " + events.evtime;
            Html = @events.evdetail;
            
        }
        /*public Item Item { get; set; }
		public ItemDetailViewModel(Item item = null)
		{
			Title = item.Text;
			Item = item;
		}*/

        int quantity = 1;
		public int Quantity
		{
			get { return quantity; }
			set { SetProperty(ref quantity, value); }
		}
	}
}