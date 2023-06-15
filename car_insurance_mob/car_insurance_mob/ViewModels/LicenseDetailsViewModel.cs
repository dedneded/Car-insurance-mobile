﻿using System;
using System.Collections.Generic;
using System.Text;
using car_insurance_mob.Models;
using car_insurance_mob.Services;

namespace car_insurance_mob.ViewModels
{
    class LicenseDetailsViewModel : BaseViewModel
    {
        public Guid licenseId;
        private LicenseService _licenseService;
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
        
        
        public LicenseDetailsViewModel(LicenseService licenseService)
        {
            _licenseService = licenseService;
        }
        public void FillInfo(Guid licenseid)
        {
            License license = _licenseService.GetLicense(licenseid);
            Id = licenseid;
            DateOfIssue = license.DateOfIssue;
            ExpirationDate = license.ExpirationDate;
            CodeGIBDD = license.CodeGIBDD;
            Series = license.Series;
            Number = license.Number;
            TransmissionType = license.TransmissionType;
            VehicleCategories = license.VehicleCategories;
            
        }
    }
}