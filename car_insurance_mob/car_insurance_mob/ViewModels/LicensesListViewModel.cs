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
    class LicensesListViewModel : BaseViewModel
    {
        private ObservableCollection<License> allLicenses;
        public ObservableCollection<License> AllLicenses
        {
            get { return allLicenses; }
            set
            {
                allLicenses = value;
            }
        }
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
        private LicenseService _licenseService;
        public LicensesListViewModel(LicenseService licenseService)
        {
            _licenseService = licenseService;
            List<License> licenses = _licenseService.GetAllLicenses();
            AllLicenses = new ObservableCollection<License>(licenses);
            SortIcon = "⇑⇓";
            ApplySortCommand = new Command(ApplySort);
        }
        private void ApplySort()
        {
            ascendingSort = !ascendingSort;
            // Изменение иконки в зависимости от направления сортировки
            SortIcon = ascendingSort ? "⇑⇓" : "⇓⇑";
        }
    }
}
