using System;
using System.Collections.Generic;
using System.Text;

namespace car_insurance_mob.Models
{
    class License
    {
        public Guid Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CodeGIBDD { get; set; }
        public string Series { get; set; }

        public string Number { get; set; }
        public string TransmissionType { get; set; }
        public string VehicleCategories { get; set; }
        public string PhotoPath { get; set; }

        public License(Guid Id, DateTime DateOfIssue, DateTime ExpirationDate, string CodeGIBDD,
            string Series, string Number, string TransmissionType, string VehicleCategories,
            string PhotoPath="")
        {
            this.Id = Id;
            this.DateOfIssue = DateOfIssue;
            this.ExpirationDate = ExpirationDate;
            this.CodeGIBDD = CodeGIBDD;
            this.Series = Series;
            this.Number = Number;
            this.TransmissionType = TransmissionType;
            this.VehicleCategories = VehicleCategories;
            this.PhotoPath = PhotoPath;


        }
    }
}
