using car_insurance_mob.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace car_insurance_mob.Services
{
    public class ClientService
    {
        
        public static Client client1 = new Client(Guid.NewGuid(), "dfgdfgdfgdf", "email228@mail.ru", DateTime.Now, DateTime.Now);
        public static Client client2 = new Client(Guid.NewGuid(), "88001112323", "email2@mail.ru", DateTime.Now, DateTime.Now);
        public static Client client3 = new Client(Guid.NewGuid(), "88001112323", "email3@mail.ru", DateTime.Now, DateTime.Now);
        public static Client client4 = new Client(Guid.NewGuid(), "88001112323", "email4@mail.ru", DateTime.Now, DateTime.Now);
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
