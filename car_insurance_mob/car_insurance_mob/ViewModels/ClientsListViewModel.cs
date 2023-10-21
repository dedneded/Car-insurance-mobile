using car_insurance_mob.Models;
using car_insurance_mob.Services;
using car_insurance_mob.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace car_insurance_mob.ViewModels
{
    internal class ClientsListViewModel : BaseViewModel
    {
        private bool Clicked = true;
        private ClientService _clientservice;
        private EmployeeService _employeeservice;
        private PassportService _passportservice;



        private string fullNameFilter;
        public string FullNameFilter
        {
            get { return fullNameFilter; }
            set
            {
                fullNameFilter = value;
                OnPropertyChanged();
            }
        }
        private string phoneFilter;
        public string PhoneFilter
        {
            get { return phoneFilter; }
            set
            {
                phoneFilter = value;
                OnPropertyChanged();
            }
        }
        private string emailFilter;
        public string EmailFilter
        {
            get { return emailFilter; }
            set
            {
                emailFilter = value;
                OnPropertyChanged();
            }
        }
        private bool ascendingSort = false; // Начальное направление сортировки
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
        public ICommand AddClientCommand { get; private set; }
        public ICommand FiltersCommand { get; private set; }
        public ICommand DropFiltersCommand { get; private set; }

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
        public ClientsListViewModel(ClientService clientservice, EmployeeService employeeService, PassportService passportService)
        {
            _clientservice = clientservice;
            _employeeservice = employeeService;
            _passportservice = passportService;
            AllClients = new ObservableCollection<Client>(_clientservice.clients);
            IsFilterVisible = false;
            ApplyFiltersCommand = new Command(ApplyFilters);
            
            ApplySortCommand = new Command(ApplySort);
            AddClientCommand = new Command(AddClient);

            FiltersCommand = new Command(Filters);
            DropFiltersCommand = new Command(DropFilters);

        }
        private void ApplyFilters()
        {

            Clicked = !Clicked;
            // Изменение иконки в зависимости от направления сортировки
            IsFilterVisible = Clicked ? false : true;

            

        }
        async void Filters()
        {
            await _clientservice.FilterClientsByNameAsync(_employeeservice, fullNameFilter, _passportservice, _clientservice);
            AllClients = new ObservableCollection<Client>(_clientservice.clients);

        }
        private void DropFilters()
        {

            AllClients = new ObservableCollection<Client>(_clientservice.clients);


        }
        async void ApplySort()
        {
            bool check = false;
            if (SortIcon == "⇑⇓")
            {
                _clientservice.OrderByClient();
                SortIcon = "⇓⇑";
                check = true;
            }

            if (SortIcon == "⇓⇑" && !check)
            {
                _clientservice.OrderByDescendingClient();
                SortIcon = "⇑⇓";
            }
            //ascendingSort = !ascendingSort;
            //// Изменение иконки в зависимости от направления сортировки
            //SortIcon = ascendingSort ? "⇑⇓" : "⇓⇑";

           
            await Application.Current.MainPage.Navigation.PushAsync(new ClientsListPage(SortIcon));
        }
        async void AddClient()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddClientPage());
        }
    }
}
