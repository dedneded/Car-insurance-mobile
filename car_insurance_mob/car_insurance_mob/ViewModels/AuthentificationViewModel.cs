﻿using System;
using System.Collections.Generic;
using System.Text;
using car_insurance_mob.Services;
using car_insurance_mob.Models;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using car_insurance_mob.Views;

namespace car_insurance_mob.ViewModels
{
    class AuthentificationViewModel : BaseViewModel
    {
        Employee currentuser;
        private EmployeeService _employeeService;
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
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
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
        public ICommand LoginCommand { get; private set; }
        public ICommand RegCommand { get; private set; }
        public AuthentificationViewModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
            RegCommand = new Command(Reg);
            LoginCommand = new Command(Login);
        }
        async void Login()
        {

            if (String.IsNullOrEmpty(Phone)) return;
            if (String.IsNullOrEmpty(Password)) return;


            Employee employee = new Employee(Phone, Password);


            if (_employeeService.Authentification(employee))
            {
                currentuser = _employeeService.GetStateUser();

                await Application.Current.MainPage.Navigation.PushAsync(new ClientsListPage());


            }
            else
            {
                Error = "Неправильный логин или пароль!";
            }


        }
        async void Reg()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
        }
    }
}