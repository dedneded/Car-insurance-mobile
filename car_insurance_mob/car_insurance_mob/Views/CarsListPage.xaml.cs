using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_insurance_mob.Models;
using car_insurance_mob.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace car_insurance_mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarsListPage : ContentPage
    {
        public CarsListPage(int _clientId)
        {
            InitializeComponent();
            (this.BindingContext as CarsListViewModel).FillId(_clientId);
        }

        private async void OnCarTapped(object sender, ItemTappedEventArgs e)
        {

            if (e.Item != null)
            {
                var car = (Car)e.Item;

                await Navigation.PushAsync(new CarDetailsPage(car.Id));
            }
        }
    }
}