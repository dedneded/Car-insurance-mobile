using car_insurance_mob.Models;
using car_insurance_mob.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace car_insurance_mob.ViewModels
{
    public class PassportsListViewModel : BaseViewModel
    {
        private ObservableCollection<Passport> allPassports;
        public ObservableCollection<Passport> AllPassports
        {
            get { return allPassports; }
            set
            {
                allPassports = value;
            }
        }
        private PassportService _passportservice;

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

        public PassportsListViewModel(PassportService passportservice)
        {
            _passportservice = passportservice;
            //List<Passport> passports = _passportservice.GetAllPassports();
            //AllPassports = new ObservableCollection<Passport>(passports);
            //SortIcon = "⇑⇓";
            //ApplySortCommand = new Command(ApplySort);
        }

        private void ApplySort()
        {
            ascendingSort = !ascendingSort;
            // Изменение иконки в зависимости от направления сортировки
            SortIcon = ascendingSort ? "⇑⇓" : "⇓⇑";
        }
    }
}
