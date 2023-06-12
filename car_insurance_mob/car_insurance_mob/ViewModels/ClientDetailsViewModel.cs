using car_insurance_mob.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xamarin.Forms;
using car_insurance_mob.Models;

namespace car_insurance_mob.ViewModels
{
    internal class ClientDetailsViewModel : BaseViewModel
    {
        private ClientService _clientservice;
        private Guid _clientId;
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
        public ClientDetailsViewModel(ClientService clientservice, Guid clientId=new Guid())
        {
            _clientservice = clientservice;
            _clientId = clientId;
            Client client = _clientservice.GetClient(clientId);
            Id = client.Id;
            Phone = client.Phone;
            Email = client.Email;
        }
    }
}
