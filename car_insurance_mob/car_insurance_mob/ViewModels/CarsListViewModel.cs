using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using car_insurance_mob.Models;
using car_insurance_mob.Services;
using car_insurance_mob.Views;
using Xamarin.Forms;

namespace car_insurance_mob.ViewModels
{
    class CarsListViewModel : BaseViewModel
    {
        int Clicked = 0;
        private int _clientId;
        private CarService _carService;
        private ClientService _clientService;
        private EmployeeService _employeeService;

        private ObservableCollection<Car> allCars;
        public ObservableCollection<Car> AllCars
        {
            get { return allCars; }
            set
            {
                allCars = value;
            }
        }
        private bool isFilterVisible;
        public bool IsFilterVisible
        {
            get { return isFilterVisible; }
            set
            {
                isFilterVisible = value;
                OnPropertyChanged();
            }
        }
       
        private string registrationNum;
        public string RegistrationNum
        {
            get { return registrationNum; }
            set
            {
                registrationNum = value;
                OnPropertyChanged();
            }
        }
        public ICommand ApplyFiltersCommand { get; private set; }
        private bool ascendingSort = true; // Начальное направление сортировки
        private string sortIcon;
        public string SortIcon
        {
            get { return sortIcon; }
            set
            {
                sortIcon = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCarCommand { get; private set; }
        public ICommand FiltersCommand { get; private set; }
        public ICommand DropFiltersCommand { get; private set; }

        public CarsListViewModel(CarService carService, ClientService clientService, EmployeeService employeeService)
        {
            _carService = carService;
            _clientService = clientService;
            _employeeService = employeeService;
            List<Car> cars = _carService.GetAllCars();
            AllCars = new ObservableCollection<Car>(cars);
            SortIcon = "⇑⇓";
            ApplyFiltersCommand = new Command(ApplyFilters);
            AddCarCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new AddCarPage(_clientId)));
            FiltersCommand = new Command(Filters);
            DropFiltersCommand = new Command(DropFilters);
        }

        private void ApplyFilters()
        {
            Clicked += 1;
            if (Clicked % 2 == 0)
            {
                IsFilterVisible = false;
            }
            else
            {
                IsFilterVisible = true;
            }

        }
      
        public void FillId(int clientId)
        {
            _clientId = clientId;
        }
        async void Filters()
        {
            if (RegistrationNum != null)
            {
                _carService.cars = await _carService.FilterCarsAsync(_clientService, _employeeService, registrationNum);
                AllCars.Clear();
                foreach (var car in _carService.cars)
                {
                    AllCars.Add(car); // Добавляем новые элементы
                }
            }
            
            
        }
        async void DropFilters()
        {
            var cars = await _carService.GetAllCarsAsync(_clientService, _employeeService, _clientId);
            AllCars.Clear();
            foreach (var car in cars)
            {
                AllCars.Add(car); // Добавляем новые элементы
            }
            RegistrationNum = "";
           
        }
    }
}
