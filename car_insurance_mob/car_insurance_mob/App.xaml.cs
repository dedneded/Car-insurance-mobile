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

            MainPage = new NavigationPage(new AuthentificationPage());
            //string str = "92e8c2b2-97d9-4d6d-a9b7-48cb0d039a84";
            //Guid idTest = new Guid(str);
            // MainPage = new NavigationPage(new PassportActualPage(idTest));



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
