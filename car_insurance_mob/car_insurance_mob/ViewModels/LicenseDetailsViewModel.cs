using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using car_insurance_mob.Models;
using car_insurance_mob.Services;
using car_insurance_mob.Views;
using Xamarin.Forms;

namespace car_insurance_mob.ViewModels
{
    class LicenseDetailsViewModel : BaseViewModel
    {
        public Guid licenseId;
        private LicenseService _licenseService;
        private ClientService _clientService;
        private EmployeeService _employeeService;
        public int lisenceId; 
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
        private string del;
        public string Del
        {
            get { return del; }
            set
            {
                del = value;
                OnPropertyChanged();
            }
        }
        public ICommand DelLicenseCommand { get; private set; }
        
        public LicenseDetailsViewModel(LicenseService licenseService, ClientService clientService, EmployeeService employeeService)
        {
            _licenseService = licenseService;
            _clientService = clientService;
            _employeeService = employeeService;
            DelLicenseCommand = new Command(DelLicense); 
        }
        public async void FillInfo(int licenseid)
        {

            License lisence = await _licenseService.GetLicenseAsync(licenseid, _clientService, _employeeService);

            Id = lisence.Id;
            lisenceId = Id;
            DateOfIssue = lisence.DateOfIssue;
            ExpirationDate = lisence.ExpirationDate;
            CodeGIBDD = lisence.CodeGIBDD;
            Series = lisence.Series;
            Number = lisence.Number;
            TransmissionType = lisence.TransmissionType;
            VehicleCategories = lisence.VehicleCategories;
            try
            {
                if (lisence.DateDel != DateTime.MinValue)
                {
                    Del = "Удален" + " " + lisence.DateDel.ToString();
                }
            }
            catch
            {

            }
        }
        public async void DelLicense()
        {
            await _licenseService.DeleteLicenseAsync(Id);
            await Application.Current.MainPage.Navigation.PushAsync(new LicenseDetailsPage(Id));
        }
    }
}
