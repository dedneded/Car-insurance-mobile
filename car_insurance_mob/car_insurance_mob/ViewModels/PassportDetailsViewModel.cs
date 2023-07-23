using System;
using System.Collections.Generic;
using System.Text;
using car_insurance_mob.Models;
using car_insurance_mob.Services;
using static Xamarin.Essentials.Permissions;
using Xamarin.Essentials;

namespace car_insurance_mob.ViewModels
{
    internal class PassportDetailsViewModel : BaseViewModel
    {
        private PassportService _passportservice;
        public Guid passportId;
        private Guid id;
        public Guid Id
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
        public PassportDetailsViewModel(PassportService _passportservice)
        {
            this._passportservice = _passportservice;
        }
        public void FillInfo(Guid passportid)
        {

            Passport passport = _passportservice.GetPassport(passportid);
           
            Id = passportid;
            //Issued_By_Whom = passport.Issued_By_Whom;
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
    }
}
