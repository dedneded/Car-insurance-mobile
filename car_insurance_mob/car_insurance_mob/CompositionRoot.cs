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
        public ClientsListViewModel ClientsListViewModel => new ClientsListViewModel(clientService);
        public ClientDetailsViewModel ClientDetailsViewModel => new ClientDetailsViewModel(clientService);
        public CompositionRoot()
        {
            this.clientService = new ClientService();

        }
    }
}
