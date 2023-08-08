using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace car_insurance_mob.Models
{
    public class License
    {
        [JsonProperty("id")]

        public int Id { get; set; }
        [JsonProperty("DateOfIssue")]

        public DateTime DateOfIssue { get; set; }
        [JsonProperty("ExpirationDate")]

        public DateTime ExpirationDate { get; set; }
        [JsonProperty("CodeGIBDD")]

        public string CodeGIBDD { get; set; }
        [JsonProperty("Series")]

        public string Series { get; set; }
        [JsonProperty("Number")]


        public string Number { get; set; }
        [JsonProperty("TransmissionType")]

        public string TransmissionType { get; set; }
        [JsonProperty("VehicleCategories")]

        public string VehicleCategories { get; set; }
        [JsonProperty("Client")]

        public Client Client { get; set; }
        [JsonProperty("DateDel")]

        public DateTime DateDel { get; set; }

        public License()
        {

        }
        /// ///CREATE LICENSE///
        //static async Task Main(string[] args)
        //{
        //    // Получаем информацию о существующем клиенте
        //    Client existingClient = await ClientService.GetClientAsync(10);

        //    if (existingClient != null)
        //    {
        //        existingClient.Id = 10;
        //        // Создаем экземпляр класса Passport с нужными данными
        //        License license = new License
        //        {
        //            DateOfIssue = DateTime.Parse("1990-01-01"),
        //            ExpirationDate = DateTime.Parse("1990-01-01"),
        //            CodeGIBDD = "123456",
        //            Series = "AB",
        //            Number = "123456",
        //            TransmissionType = "TransmissionType",
        //            VehicleCategories = "ABC",
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
        //            string response = await LicenseService.CreateLicenseAsync(license);
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
        ///CREATE LICENSE///
        //////
        ////////////////////////////////////////////////////////////////////////////////////////
        /////////UPDATE LICENSE///
        //static async Task Main(string[] args)
        //{
        //    License existingLicense = await LicenseService.GetLicenseAsync(1);

        //    if (existingLicense != null)
        //    {

        //        existingLicense.Id = 1;
        //        existingLicense.DateOfIssue = new DateTime(1990, 5, 10);
        //        existingLicense.ExpirationDate = DateTime.Now;
        //        existingLicense.CodeGIBDD = "555555";
        //        existingLicense.Series = "Новая серия";
        //        existingLicense.Number = "Новый номер";
        //        existingLicense.TransmissionType = "New TransmissionType";
        //        existingLicense.VehicleCategories = "A";
        //        //Client client = await ClientService.GetClientAsync(11);
        //        //existingLicense.Client = client;
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
        //            string response = await LicenseService.UpdateLicenseAsync(existingLicense);
        //            Console.WriteLine("License updated successfully!");
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

        ////private static byte[] ReadPhotoData(string filePath)
        ////{
        ////    using (var fileStream = File.OpenRead(filePath))
        ////    {
        ////        using (var memoryStream = new MemoryStream())
        ////        {
        ////            fileStream.CopyTo(memoryStream);
        ////            return memoryStream.ToArray();
        ////        }
        ////    }
        ////}
        ///UPDATE LICENSE///
        ////////////////////////////////////////////////////////////////////////////////////////
        ////////////GET LICENSES///
        //static async Task Main(string[] args)
        //{
        //    try
        //    {
        //        // Вызываем функцию GetAllLicensesAsync для получения списка всех прав
        //        List<License> licenses = await LicenseService.GetAllLicensesAsync();

        //        if (licenses.Count > 0)
        //        {
        //            // Выводим информацию о каждом паспорте
        //            foreach (var license in licenses)
        //            {
        //                Console.WriteLine($"ID: {license.Id}");
        //                Console.WriteLine($"DateOfIssue: {license.DateOfIssue}");
        //                Console.WriteLine($"DivisionCode: {license.ExpirationDate}");
        //                Console.WriteLine($"Series: {license.CodeGIBDD}");
        //                Console.WriteLine($"Number: {license.Series}");
        //                Console.WriteLine($"FIO: {license.Number}");
        //                Console.WriteLine($"IsMale: {license.TransmissionType}");
        //                Console.WriteLine($"DateOfBirth: {license.VehicleCategories}");
        //                Console.WriteLine($"Client: {license.Client.Id}");


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
        //////GET LICENSES///
        ////////////////////////////////////////////////////////////////////////////////////////
    }
}
