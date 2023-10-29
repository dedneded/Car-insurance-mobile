using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace car_insurance_mob.Models
{
    public class Car
    {
        [JsonProperty("id")]

        public int Id { get; set; }
        [JsonProperty("RegistrationNumber")]

        public string RegistrationNumber { get; set; }
        [JsonProperty("IdNumber")]

        public string IdNumber { get; set; }
        [JsonProperty("Brand")]

        public string Brand { get; set; }
        [JsonProperty("Model")]

        public string Model { get; set; }
        [JsonProperty("TCType")]

        public string TCType { get; set; }
        [JsonProperty("TCCategory")]

        public string TCCategory { get; set; }
        [JsonProperty("YearOfIssue")]

        public int YearOfIssue { get; set; }
        [JsonProperty("EngineModel")]

        public string EngineModel { get; set; }
        [JsonProperty("EngineNumber")]

        public string EngineNumber { get; set; }
        [JsonProperty("ChassisNumber")]

        public string ChassisNumber { get; set; }
        [JsonProperty("CarBodyNumber")]

        public string CarBodyNumber { get; set; }
        [JsonProperty("Color")]

        public string Color { get; set; }
        [JsonProperty("EnginePower")]

        public string EnginePower { get; set; }
        [JsonProperty("EngineDisplacement")]

        public int EngineDisplacement { get; set; }
        [JsonProperty("Series")]

        public string Series { get; set; }
        [JsonProperty("Number")]

        public string Number { get; set; }
        [JsonProperty("MaxWeightPermitted")]


        public int MaxWeightPermitted { get; set; }
        [JsonProperty("WeightWithoutCapacity")]

        public int WeightWithoutCapacity { get; set; }
        [JsonProperty("NameOwner")]

        public string NameOwner { get; set; }
        [JsonProperty("PlaceRegistration")]

        public string PlaceRegistration { get; set; }
        [JsonProperty("PlaceOfIssue")]

        public string PlaceOfIssue { get; set; }
        [JsonProperty("DateOfIssue")]

        public DateTime DateOfIssue { get; set; }
        [JsonProperty("Client")]

        public Client Client { get; set; }
        [JsonProperty("DateDel")]

        public DateTime DateDel { get; set; }


        public Car(int Id, string RegistrationNumber, string IdNumber, string Brand, string Model,
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
    /// ///CREATE CAR///
    //static async Task Main(string[] args)
    //{
    //    // Получаем информацию о существующем клиенте
    //    Client existingClient = await ClientService.GetClientAsync(10);

    //    if (existingClient != null)
    //    {
    //        existingClient.Id = 10;
    //        // Создаем экземпляр класса Car с нужными данными
    //        Car car = new Car
    //        {
    //            RegistrationNumber = "О832РТ",
    //            IdNumber = "123113",
    //            Brand = "Toyota",
    //            Model = "Model",
    //            TCType = "TCType",
    //            TCCategory = "TCCategory",
    //            YearOfIssue = 1999,
    //            EngineModel = "EngineModel",
    //            EngineNumber = "EngineNumber",
    //            ChassisNumber = "ChassisNumber",
    //            CarBodyNumber = "CarBodyNumber",
    //            Color = "Color",
    //            EnginePower = "113/1",
    //            EngineDisplacement = 221,
    //            Series = "AB",
    //            Number = "123456",
    //            MaxWeightPermitted = 1000,
    //            WeightWithoutCapacity = 500,
    //            NameOwner = "NameOwner",
    //            PlaceRegistration = "PlaceRegistration",
    //            PlaceOfIssue = "PlaceOfIssue",
    //            DateOfIssue = DateTime.Parse("1990-01-01"),
    //            Client = existingClient
    //        };

    //        //    // Создаем список фотографий
    //        //    List<PassportPhoto> photos = new List<PassportPhoto>
    //        //{
    //        //    new PassportPhoto { photo_path = "photo1.jpg" },
    //        //    new PassportPhoto { photo_path = "photo2.jpg" }
    //        //};

    //        //    // Связываем фотографии с паспортом
    //        //    passport.Photos = photos;

    //        try
    //        {
    //            // Вызываем функцию CreatePassportAsync для создания паспорта
    //            string response = await CarService.CreateCarAsync(car);
    //            Console.WriteLine("Car created successfully!");
    //            Console.WriteLine("Response: " + response);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine("An error occurred: " + ex.Message);
    //        }

    //    }
    //    else
    //    {
    //        Console.WriteLine("Client not found.");
    //    }
    //}
    ///CREATE CAR///
    //////
    ////////////////////////////////////////////////////////////////////////////////////////
    ////////////UPDATE CAR///
    //static async Task Main(string[] args)
    //{
    //    Car existingCar = await CarService.GetCarAsync(1);

    //    if (existingCar != null)
    //    {
    //        existingCar.Id = 1;
    //        existingCar.RegistrationNumber = "new О832РТ";
    //        existingCar.IdNumber = "new 123113";
    //        existingCar.Brand = "new Toyota";
    //        existingCar.Model = "new Model";
    //        existingCar.TCType = "new TCType";
    //        existingCar.TCCategory = "new TCCategory";
    //        existingCar.YearOfIssue = 2000;
    //        existingCar.EngineModel = "new EngineModel";
    //        existingCar.EngineNumber = "new EngineNumber";
    //        existingCar.ChassisNumber = "new ChassisNumber";
    //        existingCar.CarBodyNumber = "new CarBodyNumber";
    //        existingCar.Color = "new Color";
    //        existingCar.EnginePower = "new 113/1";
    //        existingCar.EngineDisplacement = 221;
    //        existingCar.Series = "AB";
    //        existingCar.Number = "123456";
    //        existingCar.MaxWeightPermitted = 1000;
    //        existingCar.WeightWithoutCapacity = 500;
    //        existingCar.NameOwner = "NameOwner";
    //        existingCar.PlaceRegistration = "PlaceRegistration";
    //        existingCar.PlaceOfIssue = "PlaceOfIssue";
    //        existingCar.DateOfIssue = DateTime.Parse("1990-01-01");
    //        //Client client = await ClientService.GetClientAsync(11);
    //        //existingCar.Client = client;
    //        //// Создаем новый объект фотографии
    //        //var photo1 = new PassportPhoto { FileName = "photo1.jpg", Data = ReadPhotoData("photo1.jpg") };
    //        //var photo2 = new PassportPhoto { FileName = "photo2.jpg", Data = ReadPhotoData("photo2.jpg") };

    //        //// Добавляем фотографии в паспорт
    //        //existingPassport.Photos.Clear();
    //        //existingPassport.Photos.Add(photo1);
    //        //existingPassport.Photos.Add(photo2);

    //        try
    //        {
    //            // Вызываем функцию UpdateCarAsync для обновления паспорта
    //            string response = await CarService.UpdateCarAsync(existingCar);
    //            Console.WriteLine("Car updated successfully!");
    //            Console.WriteLine("Response: " + response);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine("An error occurred: " + ex.Message);
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("Passport not found.");
    //    }
    //}

    //private static byte[] ReadPhotoData(string filePath)
    //{
    //    using (var fileStream = File.OpenRead(filePath))
    //    {
    //        using (var memoryStream = new MemoryStream())
    //        {
    //            fileStream.CopyTo(memoryStream);
    //            return memoryStream.ToArray();
    //        }
    //    }
    //}
    ///UPDATE CAR///
    ////////////////////////////////////////////////////////////////////////////////////////
    ////// /////////GET CARS///
    //static async Task Main(string[] args)
    //{
    //    try
    //    {
    //        // Вызываем функцию GetAllCarsAsync для получения списка всех авто
    //        List<Car> cars = await CarService.GetAllCarsAsync();

    //        if (cars.Count > 0) 
    //        {
    //            // Выводим информацию о каждом авто
    //            foreach (var car in cars)
    //            {
    //                Console.WriteLine($"ID: {car.Id}");
    //                Console.WriteLine($"RegistrationNumber: {car.RegistrationNumber}");
    //                Console.WriteLine($"IdNumber: {car.IdNumber}");
    //                Console.WriteLine($"Brand: {car.Brand}");
    //                Console.WriteLine($"Model: {car.Model}");
    //                Console.WriteLine($"TCType: {car.TCType}");
    //                Console.WriteLine($"TCCategory: {car.TCCategory}");
    //                Console.WriteLine($"YearOfIssue: {car.YearOfIssue}");
    //                Console.WriteLine($"EngineModel: {car.EngineModel}");
    //                Console.WriteLine($"EngineNumber: {car.EngineNumber}");
    //                Console.WriteLine($"ChassisNumber: {car.ChassisNumber}");
    //                Console.WriteLine($"CarBodyNumber: {car.CarBodyNumber}");
    //                Console.WriteLine($"Color: {car.Color}");
    //                Console.WriteLine($"EnginePower: {car.EnginePower}");
    //                Console.WriteLine($"EngineDisplacement: {car.EngineDisplacement}");
    //                Console.WriteLine($"Series: {car.Series}");
    //                Console.WriteLine($"Number: {car.Number}");
    //                Console.WriteLine($"MaxWeightPermitted: {car.MaxWeightPermitted}");
    //                Console.WriteLine($"WeightWithoutCapacity: {car.WeightWithoutCapacity}");
    //                Console.WriteLine($"NameOwner: {car.NameOwner}");
    //                Console.WriteLine($"PlaceRegistration: {car.PlaceRegistration}");
    //                Console.WriteLine($"PlaceOfIssue: {car.PlaceOfIssue}");
    //                Console.WriteLine($"DateOfIssue: {car.DateOfIssue}");

    //                Console.WriteLine($"Client: {car.Client.Id}");


    //                Console.WriteLine();
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine("No passports found.");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("An error occurred: " + ex.Message);
    //    }
    //}
    //////GET CARS///
    ////////////////////////////////////////////////////////////////////////////////////////
}
