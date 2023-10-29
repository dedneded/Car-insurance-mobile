using System;
using System.Collections.Generic;
using System.Text;
using car_insurance_mob.ViewModels;
using car_insurance_mob.Services;

namespace car_insurance_mob
{
    class CompositionRoot
    {
        readonly ClientService clientService;
        readonly PassportService passportService;
        readonly LicenseService licenseService;
        readonly CarService carService;
        readonly EmployeeService employeeService;
        public AuthentificationViewModel AuthentificationViewModel => new AuthentificationViewModel(employeeService, clientService, passportService);
        public RegistrationViewModel RegistrationViewModel => new RegistrationViewModel(employeeService);

        public ClientsListViewModel ClientsListViewModel => new ClientsListViewModel(clientService, employeeService, passportService);
        
        public ClientDetailsViewModel ClientDetailsViewModel => new ClientDetailsViewModel(clientService, employeeService, passportService, licenseService, carService);
        public PassportActualViewModel PassportActualViewModel => new PassportActualViewModel(passportService, employeeService, clientService);

        public PassportDetailsViewModel PassportDetailsViewModel => new PassportDetailsViewModel(passportService, clientService, employeeService);
        public PassportsListViewModel PassportsListViewModel => new PassportsListViewModel(passportService, clientService, employeeService);
        public AddPassportViewModel AddPassportViewModel => new AddPassportViewModel(passportService, clientService, employeeService);
        public LicenseActualViewModel LicenseActualViewModel => new LicenseActualViewModel(licenseService, clientService, employeeService);

        public LicenseDetailsViewModel LicenseDetailsViewModel => new LicenseDetailsViewModel(licenseService, clientService, employeeService);
        public LicensesListViewModel LicensesListViewModel => new LicensesListViewModel(licenseService, clientService, employeeService);
        public AddLicenseViewModel AddLicenseViewModel => new AddLicenseViewModel(licenseService, clientService, employeeService);
        public CarsListViewModel CarsListViewModel => new CarsListViewModel(carService, clientService, employeeService);

        public CarDetailsViewModel CarDetailsViewModel => new CarDetailsViewModel(carService, clientService, employeeService);
        public AddCarViewModel AddCarViewModel => new AddCarViewModel(carService, clientService, employeeService);


        public CompositionRoot()
        {
            this.clientService = new ClientService();
            this.passportService = new PassportService();
            this.licenseService = new LicenseService();
            this.carService = new CarService();
            this.employeeService = new EmployeeService();
        }
    }
}
