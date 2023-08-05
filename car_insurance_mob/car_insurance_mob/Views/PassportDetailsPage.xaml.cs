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
    public partial class PassportDetailsPage : ContentPage
    {
        public PassportDetailsPage(int passportId)
        {
            InitializeComponent();
            (this.BindingContext as PassportDetailsViewModel).FillInfo(passportId);

        }
    }
}