using car_insurance_mob.Services;
using System;
using System.Collections.Generic;
using System.Text;
using car_insurance_mob.Models;
using System.Windows.Input;
using Xamarin.Forms;
using car_insurance_mob.Views;

namespace car_insurance_mob.ViewModels
{
    class LicenseActualViewModel : BaseViewModel
    {
        private int _clientId;
        public int licenseId;
        private LicenseService _licenseService;
        private ClientService _clientService;
        private EmployeeService _employeeService;
        private string error;
        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                OnPropertyChanged();
            }
        }
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private DateTime dateOfIssue;
        public DateTime DateOfIssue
        {
            get { return dateOfIssue; }
            set
            {
                dateOfIssue = value;
                OnPropertyChanged();
            }
        }
        private DateTime expirationDate;
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set
            {
                expirationDate = value;
                OnPropertyChanged();
            }
        }
        private string codeGIBDD;
        public string CodeGIBDD
        {
            get { return codeGIBDD; }
            set
            {
                codeGIBDD = value;
                OnPropertyChanged();
            }
        }
        private string series;
        public string Series
        {
            get { return series; }
            set
            {
                series = value;
                OnPropertyChanged();
            }
        }
        private string number;
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged();
            }
        }


        private string transmissionType;
        public string TransmissionType
        {
            get { return transmissionType; }
            set
            {
                transmissionType = value;
                OnPropertyChanged();
            }
        }
        private string vehicleCategories;
        public string VehicleCategories
        {
            get { return vehicleCategories; }
            set
            {
                vehicleCategories = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddLicenseCommand { get; private set; }
        public ICommand AllLicensesCommand { get; private set; }

        public LicenseActualViewModel(LicenseService licenseService, ClientService clientService, EmployeeService employeeService)
        {
            _licenseService = licenseService;
            _clientService = clientService;
            _employeeService = employeeService;
            AddLicenseCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new AddLicensePage(_clientId)));
            AllLicensesCommand = new Command(AllLicenses);

        }
        public void FillInfo(License license, int clientId)
        {
            this._clientId = clientId;

            if (license.Id != 0)
            {
                Id = license.Id;
                DateOfIssue = license.DateOfIssue;
                ExpirationDate = license.ExpirationDate;
                CodeGIBDD = license.CodeGIBDD;
                Series = license.Series;
                Number = license.Number;
                TransmissionType = license.TransmissionType;
                VehicleCategories = license.VehicleCategories;
            }
            else
            {
                Error = "Нет добавленных автомобилей";
            }
            
        }
        public async void AllLicenses()
        {
            List<License> licenses = await _licenseService.GetAllLicensesAsync(_clientService, _employeeService, _clientId);
            _licenseService.licenses = licenses;
            await Application.Current.MainPage.Navigation.PushAsync(new LicensesListPage("",_clientId));
        }
    }
}
