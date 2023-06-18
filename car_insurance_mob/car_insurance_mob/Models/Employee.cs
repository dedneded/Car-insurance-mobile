using System;
using System.Collections.Generic;
using System.Text;

namespace car_insurance_mob.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public DateTime DateOfBirth { get; set; }

        public DateTime DateAdd { get; set; }
        public DateTime? DateDel { get; set; }
        public Employee(string FIO, string Phone, string Email, string Passwd,
            DateTime DateOfBirth, DateTime DateAdd)
        {
            this.FIO = FIO;
            this.Phone = Phone;
            this.Email = Email;
            this.Passwd = Passwd;
            this.DateOfBirth = DateOfBirth;
            this.DateAdd = DateAdd;
            

        }
        public Employee(Guid Id, string FIO, string Phone, string Email, string Passwd,
            DateTime DateOfBirth, DateTime DateAdd)
        {
            this.Id = Id;
            this.FIO = FIO;
            this.Phone = Phone;
            this.Email = Email;
            this.Passwd = Passwd;
            this.DateOfBirth = DateOfBirth;
            this.DateAdd = DateAdd;


        }
        public Employee(string Phone,string Passwd)
            
        {
            this.Phone = Phone;
            this.Passwd = Passwd;


        }

    }
}
