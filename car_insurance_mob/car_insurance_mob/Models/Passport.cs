using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace car_insurance_mob.Models
{
    public class Passport
    {
        public BigInteger? Id { get; set; }
        public string IssuedByWhom { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string DivisionCode { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }

        public string FIO { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string ResidenceAddress { get; set; }
        public Client Client { get; set; }
        public Passport(Guid Id, string Issued_By_Whom, DateTime DateOfIssue, string DivisionCode, string Series,
            string Number, string FIO, bool Sex, DateTime DateOfBirth, string PlaceOfBirth, string ResidenceAddress)
        {
            this.Id = Id;
            this.IssuedByWhom = Issued_By_Whom;
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
        ///CREATE PASSPORT///
        //static async Task Main(string[] args)
        //{
        //    // Получаем информацию о существующем клиенте
        //    Client existingClient = await ClientService.GetClientAsync(10);

        //    if (existingClient != null)
        //    {
        //        existingClient.Id = 10;
        //        // Создаем экземпляр класса Passport с нужными данными
        //        Passport passport = new Passport
        //        {
        //            IssuedByWhom = "Issuer",
        //            DateOfIssue = DateTime.Now,
        //            DivisionCode = "123456",
        //            Series = "AB",
        //            Number = "123456",
        //            FIO = "Full Name",
        //            IsMale = true,
        //            DateOfBirth = DateTime.Parse("1990-01-01"),
        //            PlaceOfBirth = "Birth Place",
        //            ResidenceAddress = "Residence Address",
        //            Client = existingClient
        //        };

        //    //    // Создаем список фотографий
        //    //    List<PassportPhoto> photos = new List<PassportPhoto>
        //    //{
        //    //    new PassportPhoto { photo_path = "photo1.jpg" },
        //    //    new PassportPhoto { photo_path = "photo2.jpg" }
        //    //};

        //    //    // Связываем фотографии с паспортом
        //    //    passport.Photos = photos;

        //        try
        //        {
        //            // Вызываем функцию CreatePassportAsync для создания паспорта
        //            string response = await PassportService.CreatePassportAsync(passport);
        //            Console.WriteLine("Passport created successfully!");
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
        ///CREATE PASSPORT
        /////////////////////////////////////////////////////////////////////////////////////
        //////UPDATE PASSPORT///
        //static async Task Main(string[] args)
        //{
        //    Passport existingPassport = await PassportService.GetPassportAsync(1);

        //    if (existingPassport != null)
        //    {
        //        existingPassport.Id = 1;
        //        existingPassport.IssuedByWhom = "Новый орган";
        //        existingPassport.DateOfIssue = DateTime.Now;
        //        existingPassport.DivisionCode = "Новый код";
        //        existingPassport.Series = "Новая серия";
        //        existingPassport.Number = "Новый номер";
        //        existingPassport.FIO = "Новое ФИО";
        //        existingPassport.IsMale = false;
        //        existingPassport.DateOfBirth = new DateTime(1990, 5, 10);
        //        existingPassport.PlaceOfBirth = "Новое место рождения";
        //        existingPassport.ResidenceAddress = "Новый адрес";
                //Client client = await ClientService.GetClientAsync(11);
                //existingPassport.Client = client;
        //        //// Создаем новый объект фотографии
        //        //var photo1 = new PassportPhoto { FileName = "photo1.jpg", Data = ReadPhotoData("photo1.jpg") };
        //        //var photo2 = new PassportPhoto { FileName = "photo2.jpg", Data = ReadPhotoData("photo2.jpg") };

        //        //// Добавляем фотографии в паспорт
        //        //existingPassport.Photos.Clear();
        //        //existingPassport.Photos.Add(photo1);
        //        //existingPassport.Photos.Add(photo2);

        //        try
        //        {
        //            // Вызываем функцию UpdatePassportAsync для обновления паспорта
        //            string response = await PassportService.UpdatePassportAsync(existingPassport);
        //            Console.WriteLine("Passport updated successfully!");
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
        ///UPDATE PASSPORT///
        ////////////////////////////////////////////////////////////////////////////////////////
        /// /////////GET PASSPORTS///
        //static async Task Main(string[] args)
        //{
        //    try
        //    {
        //        // Вызываем функцию GetAllPassportsAsync для получения списка всех паспортов
        //        List<Passport> passports = await PassportService.GetAllPassportsAsync();

        //        if (passports.Count > 0)
        //        {
        //            // Выводим информацию о каждом паспорте
        //            foreach (var passport in passports)
        //            {
        //                Console.WriteLine($"ID: {passport.Id}");
        //                Console.WriteLine($"Phone: {passport.IssuedByWhom}");
        //                Console.WriteLine($"DateOfIssue: {passport.DateOfIssue}");
        //                Console.WriteLine($"DivisionCode: {passport.DivisionCode}");
        //                Console.WriteLine($"Series: {passport.Series}");
        //                Console.WriteLine($"Number: {passport.Number}");
        //                Console.WriteLine($"FIO: {passport.FIO}");
        //                Console.WriteLine($"IsMale: {passport.IsMale}");
        //                Console.WriteLine($"DateOfBirth: {passport.DateOfBirth}");
        //                Console.WriteLine($"PlaceOfBirth: {passport.PlaceOfBirth}");
        //                Console.WriteLine($"ResidenceAddress: {passport.ResidenceAddress}");
        //                Console.WriteLine($"Client: {passport.Client}");

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
        //////GET PASSPORTS///
        ////////////////////////////////////////////////////////////////////////////////////////
        /////////DELETE PASSPORT///
        //static async Task Main(string[] args)
        //{
        //    try
        //    {
        //        // Получаем информацию о паспорте
        //        Passport passport = await PassportService.GetPassportAsync(1);

        //        if (passport != null)
        //        {
        //            //// Проверяем, есть ли фотографии у паспорта
        //            //if (passport.Photos.Count > 0)
        //            //{
        //            //    // Удаляем каждую фотографию
        //            //    foreach (var photo in passport.Photos)
        //            //    {
        //            //        await PassportPhotoService.DeletePassportPhotoAsync(photo.Id);
        //            //    }
        //            //}

        //            // Удаляем паспорт
        //            string response = await PassportService.DeletePassportAsync(1);
        //            Console.WriteLine("Passport deleted successfully!");
        //            Console.WriteLine("Response: " + response);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Passport not found.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred: " + ex.Message);
        //    }
        //}
        ///DELETE PASSPORT///
        ////////////////////////////////////////////////////////////////////////////////////////
    }
}
