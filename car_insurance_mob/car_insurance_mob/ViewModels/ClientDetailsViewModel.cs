using car_insurance_mob.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xamarin.Forms;
using car_insurance_mob.Models;
using System.Threading;
using System.Windows.Input;
using car_insurance_mob.Views;

namespace car_insurance_mob.ViewModels
{
    internal class ClientDetailsViewModel : BaseViewModel
    {
        
        private ClientService _clientservice;
        public Guid clientId;
        private Guid id;
        public Guid Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        public ICommand EditClientCommand { get; private set; }
        public ICommand GetPasportsCommand { get; private set; }
        public ICommand GetLicensesCommand { get; private set; }

        public ICommand GetCarsCommand { get; private set; }

        //public void FillInfo(Guid clientid)
        //{

        //    Client client = _clientservice.GetClient(clientid);
        //    Email = client.Email;
        //    Phone = client.Phone;
        //    Id = clientid;
            
        //}

        public ClientDetailsViewModel(ClientService clientservice)
        {
            _clientservice = clientservice;
            EditClientCommand = new Command(EditClient);
            string str = "92e8c2b2-97d9-4d6d-a9b7-48cb0d039a84";
            Guid idTest = new Guid(str);
            GetPasportsCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new PassportActualPage(idTest)));
            GetLicensesCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new LicenseActualPage(idTest)));
            GetCarsCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new CarsListPage()));
        }
        private void EditClient()
        {

        }
    }
}
