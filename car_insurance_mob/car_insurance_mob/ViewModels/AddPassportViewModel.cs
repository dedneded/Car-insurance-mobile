﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Input;
using car_insurance_mob.Models;
using car_insurance_mob.Services;
using car_insurance_mob.Views;
using Xamarin.Forms;

namespace car_insurance_mob.ViewModels
{
    class AddPassportViewModel : BaseViewModel
    {
        public int clientId;
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
        private bool isMale;
        public bool IsMale
        {
            get { return isMale; }
            set
            {
                isMale = value;
                OnPropertyChanged();
            }
        }
        private bool isFemale;
        public bool IsFemale
        {
            get { return isFemale; }
            set
            {
                isFemale = value;
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
        public ICommand SavePassportCommand { get; private set; }
        public ICommand TakePhotoCommand { get; private set; }

        private PassportService _passportService;
        private ClientService _clientService;
        private EmployeeService _employeeService;
        public AddPassportViewModel(PassportService passportService, ClientService clientService, EmployeeService employeeService)
        {
            _passportService = passportService;
            _clientService = clientService;
            _employeeService = employeeService;
            DateOfIssue = DateTime.Today;
            DateOfBirth = DateTime.Today;
            TakePhotoCommand = new Command(TakePhoto);
            SavePassportCommand = new Command(SavePassport);

        }
        public async void SavePassport()
        {
            Passport passport = new Passport();
            passport.Client = await _clientService.GetClientAsync(clientId, _employeeService);
            passport.IssuedByWhom = Issued_By_Whom;
            passport.DateOfIssue = DateOfIssue;
            passport.DivisionCode = DivisionCode;
            passport.Series = Series;
            passport.Number = Number;
            passport.FIO = FIO;
            passport.IsMale = IsMale; 
            passport.DateOfBirth = DateOfBirth;
            passport.PlaceOfBirth = PlaceOfBirth;
            passport.ResidenceAddress = ResidenceAddress;
            await _passportService.CreatePassportAsync(passport);
            List<Passport> passports = await _passportService.GetAllPassportsAsync(_clientService, _employeeService, clientId);
            _passportService.passports = passports;
            await Application.Current.MainPage.Navigation.PushAsync(new PassportsListPage());
        }
        public void TakePhoto()
        {

            
        }
    }
}
