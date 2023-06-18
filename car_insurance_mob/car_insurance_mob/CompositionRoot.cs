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
        public AuthentificationViewModel AuthentificationViewModel => new AuthentificationViewModel(employeeService);
        public RegistrationViewModel RegistrationViewModel => new RegistrationViewModel(employeeService);

        public ClientsListViewModel ClientsListViewModel => new ClientsListViewModel(clientService);
        
        public ClientDetailsViewModel ClientDetailsViewModel => new ClientDetailsViewModel(clientService);
        public PassportActualViewModel PassportActualViewModel => new PassportActualViewModel(passportService);

        public PassportDetailsViewModel PassportDetailsViewModel => new PassportDetailsViewModel(passportService);
        public PassportsListViewModel PassportsListViewModel => new PassportsListViewModel(passportService);
        public AddPassportViewModel AddPassportViewModel => new AddPassportViewModel(passportService);
        public LicenseActualViewModel LicenseActualViewModel => new LicenseActualViewModel(licenseService);

        public LicenseDetailsViewModel LicenseDetailsViewModel => new LicenseDetailsViewModel(licenseService);
        public LicensesListViewModel LicensesListViewModel => new LicensesListViewModel(licenseService);
        public AddLicenseViewModel AddLicenseViewModel => new AddLicenseViewModel(licenseService);
        public CarsListViewModel CarsListViewModel => new CarsListViewModel(carService);

        public CarDetailsViewModel CarDetailsViewModel => new CarDetailsViewModel(carService);        
        public AddCarViewModel AddCarViewModel => new AddCarViewModel(carService);


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
