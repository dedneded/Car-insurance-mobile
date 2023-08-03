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
using System.Numerics;

namespace car_insurance_mob.ViewModels
{
    internal class ClientDetailsViewModel : BaseViewModel
    {
        private EmployeeService _employeeservice;
        private ClientService _clientservice;
        private PassportService _passportservice;
        private int _clientId;
        public BigInteger? clientId;
        private BigInteger? id;
        public BigInteger? Id
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
        private string dateAdd;
        public string DateAdd
        {
            get { return dateAdd; }
            set
            {
                dateAdd = value;
                OnPropertyChanged();
            }
        }
        private string dateDel;
        public string DateDel
        {
            get { return dateDel; }
            set
            {
                dateDel = value;
                OnPropertyChanged();
            }
        }
        private string employee;
        public string Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChanged();
            }
        }
        public ICommand EditClientCommand { get; private set; }
        public ICommand GetPasportsCommand { get; private set; }
        public ICommand GetLicensesCommand { get; private set; }

        public ICommand GetCarsCommand { get; private set; }

        public async void FillInfo(int clientid)
        {

            Client client = await _clientservice.GetClientAsync(clientid, _employeeservice);
            Email = client.Email;
            Phone = client.Phone;
            Id = client.Id;
            _clientId = client.Id;
            DateAdd = client.DateAdd.ToString();
            if (client.DateDel == DateTime.MinValue)
            {
                DateDel = "-";
            }
            Employee = client.Employee.FIO;

        }

        public ClientDetailsViewModel(ClientService clientservice, EmployeeService employeeService, PassportService passportService)
        {
            _employeeservice = employeeService;
            _clientservice = clientservice;
            _passportservice = passportService;
            EditClientCommand = new Command(EditClient);
            string str = "92e8c2b2-97d9-4d6d-a9b7-48cb0d039a84";
            Guid idTest = new Guid(str);
            GetPasportsCommand = new Command(GetPasports);
            GetLicensesCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new LicenseActualPage(idTest)));
            GetCarsCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new CarsListPage()));
        }
        private void EditClient()
        {

        }
        async void GetPasports()
        {
            Passport passport  = await _passportservice.GetActualPassport(_clientservice, _employeeservice, _clientId);
            await Application.Current.MainPage.Navigation.PushAsync(new PassportActualPage(passport, _clientId));


        }
    }
}
