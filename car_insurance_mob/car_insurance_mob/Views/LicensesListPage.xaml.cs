using car_insurance_mob.Models;
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
		public LicensesListPage ()
		{
			InitializeComponent ();
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