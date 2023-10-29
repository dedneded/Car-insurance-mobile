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
    public partial class PassportsListPage : ContentPage
    {
        public PassportsListPage(string sortIcon = "⇓⇑", int clientId = 0)
        {
            InitializeComponent();
            if (sortIcon == "")
            {
                sortIcon = "⇓⇑";
            }

            (this.BindingContext as PassportsListViewModel).SortIcon = sortIcon;
            (this.BindingContext as PassportsListViewModel).ClientId = clientId;
        }
        private async void OnPassportTapped(object sender, ItemTappedEventArgs e)
        {

            if (e.Item != null)
            {
                var passport = (Passport)e.Item;

                await Navigation.PushAsync(new PassportDetailsPage(passport.Id));
            }
        }
    }
}