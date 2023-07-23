using car_insurance_mob.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using car_insurance_mob.Models;
using car_insurance_mob.Views;

namespace car_insurance_mob.ViewModels
{
    class RegistrationViewModel : BaseViewModel
    {
        private EmployeeService _employeeService;
        private string fIO;
        public string FIO
        {
            get { return fIO; }
            set
            {
                fIO = value;
                OnPropertyChanged();
            }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        private string password1;
        public string Password1
        {
            get { return password1; }
            set
            {
                password1 = value;
                OnPropertyChanged();
            }
        }
        private string password2;
        public string Password2
        {
            get { return password2; }
            set
            {
                password2 = value;
                OnPropertyChanged();
            }
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged();
            }
        }
        private string error;
        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                OnPropertyChanged();
            }
        }
        public ICommand RegCommand { get; private set; }

        public RegistrationViewModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
            RegCommand = new Command(Reg);
        }
        async void Reg()
        {
            if (String.IsNullOrEmpty(FIO)) return;
            if (String.IsNullOrEmpty(Phone)) return;
            if (String.IsNullOrEmpty(Email)) return;
            if (DateOfBirth == null) return;
            if (String.IsNullOrEmpty(Password1)) return;
            if (String.IsNullOrEmpty(Password2)) return;
            if (Password1 != Password2)
            {
                Error = "Пароли не совпадают";
                return;
            }
            Employee employee = new Employee(FIO, Phone, Email, Password1, DateOfBirth, DateTime.Now);
            //Employee employee = new Employee("Иванов Иван Иванович",
            //"88001111111", "email2@mail.ru", "111", DateTime.Now, DateTime.Now);

            try
            {
                //Вызываем функцию CreateClientAsync для создания клиента
                string response = await _employeeService.CreateEmployeeAsync(employee);
                Console.WriteLine("Employee created successfully!");
                Console.WriteLine("Response: " + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            //_employeeService.AddEmployee(employee);
            //await Application.Current.MainPage.Navigation.PushAsync(new AuthentificationPage());
        }
    }
}
