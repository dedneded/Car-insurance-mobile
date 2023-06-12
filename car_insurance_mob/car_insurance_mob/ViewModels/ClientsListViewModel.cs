using car_insurance_mob.Models;
using car_insurance_mob.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace car_insurance_mob.ViewModels
{
    internal class ClientsListViewModel : BaseViewModel
    {
        int Clicked = 0;
        private ClientService _clientservice;
        
        private ObservableCollection<Client> allClients;
        public ObservableCollection<Client> AllClients
        {
            get { return allClients; }
            set
            {
                allClients = value;
            }
        }
        private bool isFilterVisible;
        public bool IsFilterVisible
        {
            get { return isFilterVisible; }
            set
            {
                isFilterVisible = value;
                OnPropertyChanged();
            }
        }
        public ICommand ApplyFiltersCommand { get; private set; }

        public ClientsListViewModel(ClientService clientservice)
        {
            _clientservice = clientservice;
            List <Client> clients = _clientservice.GetAllClients();
            AllClients = new ObservableCollection<Client>(clients);
            IsFilterVisible = true;
            ApplyFiltersCommand = new Command(ApplyFilters);

        }
        private void ApplyFilters()
        {
            Clicked += 1;
            if (Clicked % 2 == 0 )
            {
                IsFilterVisible = false;
            }
            else
            {
                IsFilterVisible = true;
            }

           // After adding new entry to database close this page
           //await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
