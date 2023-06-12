using car_insurance_mob.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace car_insurance_mob.Services
{
    internal class ClientService
    {
        public static Client client1 = new Client(new Guid("a2273733-98bd-4195-945f-e532948ff1ef"
), "dfgdfgdfgdf", "email228@mail.ru", DateTime.Now, DateTime.Now);
        public static Client client2 = new Client(new Guid("a2273733-99bd-4195-945f-e532948ff1ef"
), "88001112323", "email2@mail.ru", DateTime.Now, DateTime.Now);
        public static Client client3 = new Client(new Guid("a2273733-97bd-4195-945f-e532948ff1ef"
), "88001112323", "email3@mail.ru", DateTime.Now, DateTime.Now);
        public static Client client4 = new Client(new Guid("a2273733-96bd-4195-945f-e532948ff1ef"
), "88001112323", "email4@mail.ru", DateTime.Now, DateTime.Now);
        public List<Client> clients = new List<Client> { client1, client2, client3, client4 };
        public Client GetClient(Guid id)
        {
            Client client = null;
            foreach (Client i in clients)
            {
                if (i.Id == id)
                {
                    client = i;
                }


            }
            return client;
        }
        public List<Client> GetAllClients()
        {
            return clients;
        }
    }
}
