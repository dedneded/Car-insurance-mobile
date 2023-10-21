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
    public partial class ClientsListPage : ContentPage
    {
        public ClientsListPage(string sortIcon = "⇓⇑")
        {
            InitializeComponent();
            (this.BindingContext as ClientsListViewModel).SortIcon = sortIcon;
        }
        private async void OnClientTapped(object sender, ItemTappedEventArgs e)
        {

            if (e.Item != null)
            {
                var client = (Client)e.Item;

                await Navigation.PushAsync(new ClientDetailsPage(client.Id));
            }
        }
       
    }
}