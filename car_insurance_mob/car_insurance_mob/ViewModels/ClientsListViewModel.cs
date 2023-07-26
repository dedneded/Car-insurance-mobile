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
        public ICommand AddClientCommand { get; private set; }

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
            
            AllClients = new ObservableCollection<Client>(_clientservice.clients);
            IsFilterVisible = false;
            ApplyFiltersCommand = new Command(ApplyFilters);
            SortIcon = "⇑⇓";
            
            ApplySortCommand = new Command(ApplySort);
            AddClientCommand = new Command(AddClient);

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
        async void AddClient()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddClientPage());
        }
    }
}
