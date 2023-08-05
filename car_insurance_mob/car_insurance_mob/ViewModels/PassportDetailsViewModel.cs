using System;
using System.Collections.Generic;
using System.Text;
using car_insurance_mob.Models;
using car_insurance_mob.Services;
using static Xamarin.Essentials.Permissions;
using Xamarin.Essentials;
using System.Windows.Input;
using Xamarin.Forms;
using car_insurance_mob.Views;

namespace car_insurance_mob.ViewModels
{
    internal class PassportDetailsViewModel : BaseViewModel
    {
        private PassportService _passportservice;
        private ClientService _clientService;
        private EmployeeService _employeeService;
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
        public ICommand DelPassportCommand { get; private set; }

        public PassportDetailsViewModel(PassportService _passportservice, ClientService _clientService, EmployeeService _employeeService)
        {
            this._passportservice = _passportservice;
            this._clientService = _clientService;
            this._employeeService = _employeeService;
            DelPassportCommand = new Command(DelPassport);

        }
        public async void FillInfo(int passportId)
        {

            Passport passport = await _passportservice.GetPassportAsync(passportId, _clientService, _employeeService);
           
            Id = passport.Id;
            passportId = Id;
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
            try
            {
                if (passport.DateDel != DateTime.MinValue)
                {
                    Del = "Удален"+" "+passport.DateDel.ToString();
                }
            }
            catch {
                
            }
           
           
           
        }
        public async void DelPassport()
        {
            await _passportservice.DeletePassportAsync(Id);
            await Application.Current.MainPage.Navigation.PushAsync(new PassportDetailsPage(Id));


        }
    }
}
