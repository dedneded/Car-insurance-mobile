using car_insurance_mob.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace car_insurance_mob
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ClientsListPage());
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
