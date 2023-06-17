using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace car_insurance_mob.Models
{
    public class Car
    {
        public Guid Id { get; set; }

        public string RegistrationNumber { get; set; }
        public string IdNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string TCType { get; set; }
        public string TCCategory { get; set; }
        public int YearOfIssue { get; set; }
        public string EngineModel { get; set; }
        public string EngineNumber { get; set; }
        public string ChassisNumber { get; set; }
        public string CarBodyNumber { get; set; }
        public string Color { get; set; }
        public string EnginePower { get; set; }
        public int EngineDisplacement { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }

        public int MaxWeightPermitted { get; set; }
        public int WeightWithoutCapacity { get; set; }
        public string NameOwner { get; set; }
        public string PlaceRegistration { get; set; }

        public string PlaceOfIssue { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string photo_path { get; set; } = "";

        public Car(Guid Id, string RegistrationNumber, string IdNumber, string Brand, string Model,
            string TCType, string TCCategory, int YearOfIssue, string EngineModel,
            string EngineNumber, string ChassisNumber, string CarBodyNumber, string Color,
            string EnginePower, int EngineDisplacement, string Series, string Number,
            int MaxWeightPermitted, int WeightWithoutCapacity, string NameOwner,
            string PlaceRegistration, string PlaceOfIssue, DateTime dateOfIssue)
        {
            this.Id = Id;
            this.RegistrationNumber = RegistrationNumber;
            this.IdNumber = IdNumber;
            this.Brand = Brand;
            this.Model = Model;
            this.TCType = TCType;
            this.TCCategory = TCCategory;
            this.YearOfIssue = YearOfIssue;
            this.EngineModel = EngineModel;
            this.EngineNumber = EngineNumber;
            this.ChassisNumber = ChassisNumber;
            this.CarBodyNumber = CarBodyNumber;
            this.Color = Color;
            this.EnginePower = EnginePower;
            this.EngineDisplacement = EngineDisplacement;
            this.Series = Series;
            this.Number = Number;
            this.MaxWeightPermitted = MaxWeightPermitted;
            this.WeightWithoutCapacity = WeightWithoutCapacity;
            this.NameOwner = NameOwner;
            this.PlaceRegistration = PlaceRegistration;
            this.PlaceOfIssue = PlaceOfIssue;
            DateOfIssue = dateOfIssue;

        }
        public Car()
        {
            
        }
    }
}
