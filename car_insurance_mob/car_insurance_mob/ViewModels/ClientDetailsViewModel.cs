using car_insurance_mob.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xamarin.Forms;
using car_insurance_mob.Models;
using System.Threading;

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
        public void FillInfo(Guid clientid)
        {

            Client client = _clientservice.GetClient(clientid);
            Email = client.Email;
            Phone = client.Phone;
            Id = clientid;

        }


        public ClientDetailsViewModel(ClientService clientservice)
        {
            _clientservice = clientservice;

        }
       
    }
}
