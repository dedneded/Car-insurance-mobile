using System;
using System.Collections.Generic;
using System.Text;
using car_insurance_mob.Services;
using car_insurance_mob.Models;
using Xamarin.Forms;
using car_insurance_mob.Views;
using System.Windows.Input;
using System.ComponentModel;
using System.Security.Cryptography;

namespace car_insurance_mob.ViewModels
{
    class CarDetailsViewModel : BaseViewModel
    {
        private CarService _carService;
        private ClientService _clientService;
        private EmployeeService _employeeService;
        public int carId;
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
        private bool _isDeleted;
        public bool IsDeleted
        {
            get => _isDeleted;
            set
            {
                _isDeleted = value;
                OnPropertyChanged(); 
            }
        }
        public ICommand DelCarCommand { get; private set; }

        public CarDetailsViewModel(CarService carService, ClientService clientService, EmployeeService employeeService)
        {
            _carService = carService;
            _clientService = clientService;
            _employeeService = employeeService;
            DelCarCommand = new Command(DelCar);
            IsDeleted = true;
        }
        public async void DelCar()
        {
            await _carService.DeleteCarAsync(Id);
            await Application.Current.MainPage.Navigation.PushAsync(new CarDetailsPage(Id));
        }
        
        public async void FillInfo(int carId)
        {

            Car car = await _carService.GetCarAsync(carId, _clientService, _employeeService);
            Id = carId;
            Brand = car.Brand;
            CarBodyNumber = car.CarBodyNumber;
            ChassisNumber = car.ChassisNumber;
            Color = car.Color;
            TCCategory = car.TCCategory;
            EnginePower = car.EnginePower;
            EngineNumber = car.EngineNumber;
            IdNumber = car.IdNumber;
            RegistrationNumber = car.RegistrationNumber;
            Model = car.Model;
            TCType = car.TCType;
            YearOfIssue = car.YearOfIssue;
            PlaceRegistration = car.PlaceRegistration;
            PlaceOfIssue = car.PlaceOfIssue;
            EngineModel = car.EngineModel;
            EngineDisplacement = car.EngineDisplacement;
            Series = car.Series;
            Number = car.Number;
            MaxWeightPermitted = car.MaxWeightPermitted;
            WeightWithoutCapacity = car.WeightWithoutCapacity;
            NameOwner = car.NameOwner;
            DateOfIssue = car.DateOfIssue;
            try
            {
                if (car.DateDel != DateTime.MinValue)
                {
                    Del = "Удален" + " " + car.DateDel.ToString();
                    IsDeleted = false;
                }
            }
            catch
            {

            }


        }
    }
}
