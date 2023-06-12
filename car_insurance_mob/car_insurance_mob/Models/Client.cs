using System;
using System.Collections.Generic;
using System.Text;

namespace car_insurance_mob.Models
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateDel { get; set; }
       
       

        public Client(string Phone, string Email, DateTime DateAdd, DateTime DateDel)
        {

            this.Phone = Phone;
            this.Email = Email;
            this.DateAdd = DateAdd;
            this.DateDel = DateDel;
        }
        public Client(Guid Id, string Phone, string Email, DateTime DateAdd, DateTime DateDel)
        {
            this.Id = Id;
            this.Phone = Phone;
            this.Email = Email;
            this.DateAdd = DateAdd;
            this.DateDel = DateDel;
        }
       
    }
}
