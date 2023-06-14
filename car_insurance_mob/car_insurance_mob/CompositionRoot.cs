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
        public ClientsListViewModel ClientsListViewModel => new ClientsListViewModel(clientService);
        
        public ClientDetailsViewModel ClientDetailsViewModel => new ClientDetailsViewModel(clientService);
        public PassportDetailsViewModel PassportDetailsViewModel => new PassportDetailsViewModel(passportService);
        public PassportsListViewModel PassportsListViewModel => new PassportsListViewModel(passportService);


        public CompositionRoot()
        {
            this.clientService = new ClientService();
            this.passportService = new PassportService();
        }
    }
}
