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
    public partial class PassportActualPage : ContentPage
    {
        public PassportActualPage(Guid idActualPassport)
        {
            InitializeComponent();
            (this.BindingContext as PassportActualViewModel).FillInfo(idActualPassport);

        }
    }
}