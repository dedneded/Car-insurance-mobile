using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using car_insurance_mob.Services;
using Xamarin.Forms;
using car_insurance_mob.Models;
using car_insurance_mob.Views;

namespace car_insurance_mob.ViewModels
{
    class AddLicenseViewModel : BaseViewModel
    {
        private LicenseService _licenseService;
        private ClientService _clientService;
        private EmployeeService _employeeService;
        public int clientId;
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
        public ICommand SaveLicenseCommand { get; private set; }
        public ICommand TakePhotoCommand { get; private set; }
        public AddLicenseViewModel(LicenseService licenseService, ClientService clientService, EmployeeService employeeService)
        {
            _licenseService = licenseService;
            _clientService = clientService;
            _employeeService = employeeService;
            DateOfIssue = DateTime.Today;
            ExpirationDate = DateTime.Today;
            TakePhotoCommand = new Command(TakePhoto);
            SaveLicenseCommand = new Command(SaveLicense);
        }
        private void TakePhoto() { }
        private async void SaveLicense()
        {
            License license = new License();
            license.Client = await _clientService.GetClientAsync(clientId, _employeeService);
            license.Number = Number;
            license.VehicleCategories = VehicleCategories;
            license.Series = Series;
            license.CodeGIBDD = CodeGIBDD;
            license.DateOfIssue = DateOfIssue;
            license.ExpirationDate = ExpirationDate;
            license.TransmissionType = TransmissionType;
            await _licenseService.CreateLicenseAsync(license);
            List<License> licenses = await _licenseService.GetAllLicensesAsync(_clientService, _employeeService);
            _licenseService.licenses = licenses;
            await Application.Current.MainPage.Navigation.PushAsync(new LicensesListPage());
        }
    }
}
