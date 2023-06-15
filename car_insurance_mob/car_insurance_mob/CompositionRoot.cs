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
        public ClientsListViewModel ClientsListViewModel => new ClientsListViewModel(clientService);
        
        public ClientDetailsViewModel ClientDetailsViewModel => new ClientDetailsViewModel(clientService);
        public PassportDetailsViewModel PassportDetailsViewModel => new PassportDetailsViewModel(passportService);
        public PassportsListViewModel PassportsListViewModel => new PassportsListViewModel(passportService);
        public AddPassportViewModel AddPassportViewModel => new AddPassportViewModel(passportService);
        public LicenseDetailsViewModel LicenseDetailsViewModel => new LicenseDetailsViewModel(licenseService);
        public LicensesListViewModel LicensesListViewModel => new LicensesListViewModel(licenseService);


        public CompositionRoot()
        {
            this.clientService = new ClientService();
            this.passportService = new PassportService();
            this.licenseService = new LicenseService();
        }
    }
}
