using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_insurance_mob.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using car_insurance_mob.Services;
using car_insurance_mob.Models;

namespace car_insurance_mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientDetailsPage : ContentPage
    {
        public ClientDetailsPage(Guid clientId)
        {
            


            InitializeComponent();
            //(this.BindingContext as ClientDetailsViewModel).FillInfo(clientId);

        }


    }
}