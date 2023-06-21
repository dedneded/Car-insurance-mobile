using car_insurance_mob.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using car_insurance_mob.Services;
using car_insurance_mob.Models;
using System.Threading.Tasks;

namespace car_insurance_mob
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new RegistrationPage());
            




        }
      
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
