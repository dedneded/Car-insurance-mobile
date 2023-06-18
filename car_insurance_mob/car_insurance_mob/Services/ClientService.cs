using car_insurance_mob.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace car_insurance_mob.Services
{
    public class ClientService
    {
        public static string str = "92e8c2b2-97d9-4d6d-a9b7-48cb0d039a84";
        public static Guid idTest = new Guid(str);
        public static Client client1 = new Client(idTest, "88001111111", "email1@mail.ru", DateTime.Now, DateTime.Now);
        public static Client client2 = new Client(Guid.NewGuid(), "88002222222", "email2@mail.ru", DateTime.Now, DateTime.Now);
        public static Client client3 = new Client(Guid.NewGuid(), "88003333333", "email3@mail.ru", DateTime.Now, DateTime.Now);
        public static Client client4 = new Client(Guid.NewGuid(), "88004444444", "email4@mail.ru", DateTime.Now, DateTime.Now);
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
