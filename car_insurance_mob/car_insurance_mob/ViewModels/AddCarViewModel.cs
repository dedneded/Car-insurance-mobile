﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using car_insurance_mob.Services;
using Xamarin.Forms;
using car_insurance_mob.Models;

namespace car_insurance_mob.ViewModels
{
    class AddCarViewModel : BaseViewModel
    {
        private CarService _carService;
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
        private string registrationNumber;
        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                registrationNumber = value;
                OnPropertyChanged();
            }
        }
        private string idNumber;
        public string IdNumber
        {
            get { return idNumber; }
            set
            {
                idNumber = value;
                OnPropertyChanged();
            }
        }
        private string brand;
        public string Brand
        {
            get { return brand; }
            set
            {
                brand = value;
                OnPropertyChanged();
            }
        }
        private string model;
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged();
            }
        }
        private string tCType;
        public string TCType
        {
            get { return tCType; }
            set
            {
                tCType = value;
                OnPropertyChanged();
            }
        }
        private string tCCategory;
        public string TCCategory
        {
            get { return tCCategory; }
            set
            {
                tCCategory = value;
                OnPropertyChanged();
            }
        }
        private int yearOfIssue;
        public int YearOfIssue
        {
            get { return yearOfIssue; }
            set
            {
                yearOfIssue = value;
                OnPropertyChanged();
            }
        }
        private string engineModel;
        public string EngineModel
        {
            get { return engineModel; }
            set
            {
                engineModel = value;
                OnPropertyChanged();
            }
        }
        private string engineNumber;
        public string EngineNumber
        {
            get { return engineNumber; }
            set
            {
                engineNumber = value;
                OnPropertyChanged();
            }
        }
        private string chassisNumber;
        public string ChassisNumber
        {
            get { return chassisNumber; }
            set
            {
                chassisNumber = value;
                OnPropertyChanged();
            }
        }
        private string carBodyNumber;
        public string CarBodyNumber
        {
            get { return carBodyNumber; }
            set
            {
                carBodyNumber = value;
                OnPropertyChanged();
            }
        }
        private string color;
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged();
            }
        }
        private string enginePower;
        public string EnginePower
        {
            get { return enginePower; }
            set
            {
                enginePower = value;
                OnPropertyChanged();
            }
        }
        private int engineDisplacement;
        public int EngineDisplacement
        {
            get { return engineDisplacement; }
            set
            {
                engineDisplacement = value;
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
        private int maxWeightPermitted;
        public int MaxWeightPermitted
        {
            get { return maxWeightPermitted; }
            set
            {
                maxWeightPermitted = value;
                OnPropertyChanged();
            }
        }
        private int weightWithoutCapacity;
        public int WeightWithoutCapacity
        {
            get { return weightWithoutCapacity; }
            set
            {
                weightWithoutCapacity = value;
                OnPropertyChanged();
            }
        }
        private string nameOwner;
        public string NameOwner
        {
            get { return nameOwner; }
            set
            {
                nameOwner = value;
                OnPropertyChanged();
            }
        }
        private string placeRegistration;
        public string PlaceRegistration
        {
            get { return placeRegistration; }
            set
            {
                placeRegistration = value;
                OnPropertyChanged();
            }
        }
        private string placeOfIssue;
        public string PlaceOfIssue
        {
            get { return placeOfIssue; }
            set
            {
                placeOfIssue = value;
                OnPropertyChanged();
            }
        }
        public ICommand SaveCarCommand { get; private set; }
        public ICommand TakePhotoCommand { get; private set; }


        public AddCarViewModel(CarService carService)
        {
            _carService = carService;
            TakePhotoCommand = new Command(TakePhoto);
            SaveCarCommand = new Command(SaveLicense);
        }
        private void TakePhoto() { }
        private void SaveLicense()
        {
            Car car = new Car();
            car.Id = Id;
            car.Brand = Brand;
            car.CarBodyNumber = CarBodyNumber;
            car.ChassisNumber = ChassisNumber;
            car.Color = Color;
            TCCategory = car.TCCategory;
            car.EnginePower = EnginePower;
            car.EngineNumber = EngineNumber;
            car.IdNumber = IdNumber;
            car.RegistrationNumber = RegistrationNumber;
            car.Model = Model;
            car.TCType = TCType;
            car.YearOfIssue = YearOfIssue;
            car.PlaceRegistration = PlaceRegistration;
            car.PlaceOfIssue = PlaceOfIssue;
            car.EngineModel = EngineModel;
            car.EngineDisplacement = EngineDisplacement;
            car.Series = Series;
            car.Number = Number;
            car.MaxWeightPermitted = MaxWeightPermitted;
            car.WeightWithoutCapacity = WeightWithoutCapacity;
            car.NameOwner = NameOwner;
            car.DateOfIssue = DateOfIssue;
            _carService.AddCar(car);


        }
    }
}
