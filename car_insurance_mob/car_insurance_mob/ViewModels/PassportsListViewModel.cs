using car_insurance_mob.Models;
using car_insurance_mob.Services;
using car_insurance_mob.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace car_insurance_mob.ViewModels
{
    public class PassportsListViewModel : BaseViewModel
    {
        private PassportService _passportservice;
        private ClientService _clientService;
        private EmployeeService _employeeService;
        
        private ObservableCollection<Passport> allPassports;
        public ObservableCollection<Passport> AllPassports
        {
            get { return allPassports; }
            set
            {
                allPassports = value;
            }
        }

        private string sortIcon;
        public string SortIcon
        {
            get { return sortIcon; }
            set
            {
                sortIcon = value;
                OnPropertyChanged();
            }
        }
        private int clientId;
        public int ClientId
        {
            get { return clientId; }
            set
            {
                clientId = value;
                OnPropertyChanged();
            }
        }
        public ICommand ApplySortCommand { get; private set; }

        public PassportsListViewModel(PassportService passportservice, ClientService clientService, EmployeeService employeeService)
        {
            _passportservice = passportservice;
            _clientService = clientService;
            _employeeService = employeeService;
            List<Passport> passports = _passportservice.GetAllPassports();
            AllPassports = new ObservableCollection<Passport>(passports);
            SortIcon = "⇑⇓";
            ApplySortCommand = new Command(ApplySort);
        }

        async void ApplySort()
        {
            bool check = false;
            if (SortIcon == "⇑⇓")
            {
                List<Passport> passports = await _passportservice.GetAllPassportsAsync(_clientService, _employeeService, clientId);
                AllPassports.Clear();
                foreach (var passport in passports)
                {
                    AllPassports.Add(passport); // Добавляем новые элементы
                }
                SortIcon = "⇓⇑";
                check = true;
            }

            if (SortIcon == "⇓⇑" && !check)
            {
                List<Passport> passports = await _passportservice.GetAllPassportsDescAsync(_clientService, _employeeService, clientId);
                AllPassports.Clear();
                foreach (var passport in passports)
                {
                    AllPassports.Add(passport); // Добавляем новые элементы
                }
                SortIcon = "⇑⇓";
            }
        }
    }
}
