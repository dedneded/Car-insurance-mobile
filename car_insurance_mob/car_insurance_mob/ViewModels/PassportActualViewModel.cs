using car_insurance_mob.Models;
using car_insurance_mob.Services;
using car_insurance_mob.Views;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace car_insurance_mob.ViewModels
{
    class PassportActualViewModel : BaseViewModel
    {
        private PassportService _passportservice;
        private ClientService _clientService;
        private EmployeeService _employeeService;
        private int _clientId;
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
        private string issued_By_Whom;
        public string Issued_By_Whom
        {
            get { return issued_By_Whom; }
            set
            {
                issued_By_Whom = value;
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
        private string divisionCode;
        public string DivisionCode
        {
            get { return divisionCode; }
            set
            {
                divisionCode = value;
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
        private string fIO;
        public string FIO
        {
            get { return fIO; }
            set
            {
                fIO = value;
                OnPropertyChanged();
            }
        }


        private string sex;
        public string Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                OnPropertyChanged();
            }
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged();
            }
        }
        private string placeOfBirth;
        public string PlaceOfBirth
        {
            get { return placeOfBirth; }
            set
            {
                placeOfBirth = value;
                OnPropertyChanged();
            }
        }
        private string residenceAddress;
        public string ResidenceAddress
        {
            get { return residenceAddress; }
            set
            {
                residenceAddress = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddPasportCommand { get; private set; }
        public ICommand AllPasportsCommand { get; private set; }


        public PassportActualViewModel(PassportService _passportservice, EmployeeService _employeeService, ClientService _clientService)
        {
            this._passportservice = _passportservice;
            this._employeeService = _employeeService;
            this._clientService = _clientService;
            AddPasportCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new AddPassportPage(_clientId)));
            AllPasportsCommand = new Command(AllPasports);



        }
        public void FillInfo(Passport passport, int clientId)
        {
            this._clientId = clientId;
            if (passport.Id != 0)
            {
               
                Id = passport.Id;
                Issued_By_Whom = passport.IssuedByWhom;
                DateOfIssue = passport.DateOfIssue;
                DivisionCode = passport.DivisionCode;
                Series = passport.Series;
                Number = passport.Number;
                FIO = passport.FIO;
                Sex = passport.IsMale ? "Мужчина" : "Женщина"; ;
                DateOfBirth = passport.DateOfBirth;
                PlaceOfBirth = passport.PlaceOfBirth;
                ResidenceAddress = passport.ResidenceAddress;
            }
            else
            {
                Error = "Нет добавленных паспортов";
            }
                
            

        }
        public async void AllPasports()
        {
            List<Passport> passports = await _passportservice.GetAllPassportsAsync(_clientService, _employeeService, _clientId);
            _passportservice.passports = passports;
            await Application.Current.MainPage.Navigation.PushAsync(new PassportsListPage("",_clientId));

        }


    }
}
