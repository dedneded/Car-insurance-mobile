using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using car_insurance_mob.Models;
using car_insurance_mob.Services;
using car_insurance_mob.Views;
using Xamarin.Forms;

namespace car_insurance_mob.ViewModels
{
    class LicensesListViewModel : BaseViewModel
    {
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
        private ObservableCollection<License> allLicenses;
        public ObservableCollection<License> AllLicenses
        {
            get { return allLicenses; }
            set
            {
                allLicenses = value;
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

        public ICommand ApplySortCommand { get; private set; }
        private LicenseService _licenseService;
        private ClientService _clientService;
        private EmployeeService _employeeService;
        public LicensesListViewModel(LicenseService licenseService, ClientService clientService, EmployeeService employeeService)
        {
            _licenseService = licenseService;
            _clientService = clientService;
            _employeeService = employeeService;

            List<License> licenses = _licenseService.GetAllLicenses();
            AllLicenses = new ObservableCollection<License>(licenses);
            SortIcon = "⇑⇓";
            ApplySortCommand = new Command(ApplySort);
        }
        async void ApplySort()
        {
            bool check = false;
            if (SortIcon == "⇑⇓")
            {
                List<License> licenses = await _licenseService.GetAllLicensesAsync(_clientService, _employeeService, clientId);
                AllLicenses.Clear();
                foreach (var license in licenses)
                {
                    AllLicenses.Add(license); // Добавляем новые элементы
                }
                SortIcon = "⇓⇑";
                check = true;
            }

            if (SortIcon == "⇓⇑" && !check)
            {
                List<License> licenses = await _licenseService.GetAllLicensesDescAsync(_clientService, _employeeService, clientId);
                AllLicenses.Clear();
                foreach (var license in licenses)
                {
                    AllLicenses.Add(license); // Добавляем новые элементы
                }
                SortIcon = "⇑⇓";
            }
        }
    }
}
