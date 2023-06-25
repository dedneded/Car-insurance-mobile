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
    internal class ClientsListViewModel : BaseViewModel
    {
        private bool Clicked = true;
        private ClientService _clientservice;
        private EmployeeService _employeeservice;

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

        private ObservableCollection<Client> allClients;
        public ObservableCollection<Client> AllClients
        {
            get { return allClients; }
            set
            {
                allClients = value;
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

        public ClientsListViewModel(ClientService clientservice, EmployeeService employeeService)
        {
            _clientservice = clientservice;
            _employeeservice = employeeService;
            List <Client> clients = _clientservice.GetAllClients();
            AllClients = new ObservableCollection<Client>(clients);
            IsFilterVisible = false;
            ApplyFiltersCommand = new Command(ApplyFilters);
            SortIcon = "⇑⇓";
            
            ApplySortCommand = new Command(ApplySort);

        }
        private void ApplyFilters()
        {
            Clicked = !Clicked;
            // Изменение иконки в зависимости от направления сортировки
            IsFilterVisible = Clicked ? false : true;
            

        }
        private void ApplySort()
        {
            ascendingSort = !ascendingSort;
            // Изменение иконки в зависимости от направления сортировки
            SortIcon = ascendingSort ? "⇑⇓" : "⇓⇑";
        }
    }
}
