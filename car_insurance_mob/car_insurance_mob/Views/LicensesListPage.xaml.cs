using car_insurance_mob.Models;
using car_insurance_mob.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace car_insurance_mob.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LicensesListPage : ContentPage
	{
		public LicensesListPage (string sortIcon = "⇓⇑", int clientId=0)
		{

			InitializeComponent ();
            if (sortIcon == "")
            {
                sortIcon = "⇓⇑";
            }
               
            (this.BindingContext as LicensesListViewModel).SortIcon = sortIcon;
            (this.BindingContext as LicensesListViewModel).ClientId = clientId;
        }
        private async void OnLicenseTapped(object sender, ItemTappedEventArgs e)
        {

            if (e.Item != null)
            {
                var license = (License)e.Item;

                await Navigation.PushAsync(new LicenseDetailsPage(license.Id));
            }
        }
    }
}