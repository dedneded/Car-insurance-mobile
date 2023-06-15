using System;
using System.Collections.Generic;
using System.Text;

namespace car_insurance_mob.Models
{
    public class Passport
    {
        public Guid Id { get; set; }
        public string Issued_By_Whom { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string DivisionCode { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }

        public string FIO { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string ResidenceAddress { get; set; }
        public Passport(Guid Id, string Issued_By_Whom, DateTime DateOfIssue, string DivisionCode, string Series,
            string Number, string FIO, bool Sex, DateTime DateOfBirth, string PlaceOfBirth, string ResidenceAddress)
        {
            this.Id = Id;
            this.Issued_By_Whom = Issued_By_Whom;
            this.DateOfIssue = DateOfIssue; 
            this.DivisionCode = DivisionCode;
            this.Series = Series;
            this.Number = Number;
            this.FIO = FIO;
            this.DateOfBirth = DateOfBirth;
            this.PlaceOfBirth = PlaceOfBirth;
            this.ResidenceAddress = ResidenceAddress;




        }
        public Passport()
        {
            
        }
    }
}
