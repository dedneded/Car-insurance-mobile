using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using car_insurance_mob.Models;
using car_insurance_mob.Services;
using Xamarin.Forms;

namespace car_insurance_mob.ViewModels
{
    class CarsListViewModel : BaseViewModel
    {
        int Clicked = 0;
        private CarService _carService;
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
        public ICommand ApplySortCommand { get; private set; }

        public CarsListViewModel(CarService carService)
        {
            _carService = carService;
            List<Car> cars = _carService.GetAllCars();
            AllCars = new ObservableCollection<Car>(cars);
            SortIcon = "⇑⇓";
            ApplyFiltersCommand = new Command(ApplyFilters);
            ApplySortCommand = new Command(ApplySort);
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
        private void ApplySort()
        {
            ascendingSort = !ascendingSort;
            // Изменение иконки в зависимости от направления сортировки
            SortIcon = ascendingSort ? "⇑⇓" : "⇓⇑";
        }
    }
}
