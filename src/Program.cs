using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotwireCarStalker.Configuration;
using HotwireCarStalker.Model.Contracts;
using HotwireCarStalker.Services;
using HotwireCarStalker.Util;
using Microsoft.Extensions.Configuration;

namespace HotwireCarStalker
{
    class Program
    {
        private static AppSettings _config;

        static void Main(string[] args)
        {
            _config = LoadConfigs();
            MakeThingsHappen().Wait();
        }

        private static AppSettings LoadConfigs()
        {
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json");

            var config = builder.Build();

            var appSettings = new AppSettings();
            config.GetSection("HotWireApi").Bind(appSettings.HotWireApi);
            config.GetSection("SearchCriteria").Bind(appSettings.SearchCriteria);
            config.GetSection("Email").Bind(appSettings.Email);

            Console.WriteLine(appSettings.HotWireApi.Key);

            Console.WriteLine(appSettings.Email.AlertEmailFrom);
            Console.WriteLine(appSettings.Email.AlertEmailSubject);
            Console.WriteLine(appSettings.Email.AlertEmailTo);
            Console.WriteLine(appSettings.Email.SmtpPassword);
            Console.WriteLine(appSettings.Email.SmtpServer);
            Console.WriteLine(appSettings.Email.SmtpPort);
            Console.WriteLine(appSettings.Email.SmtpUser);

            return appSettings;
        }

        private static async Task MakeThingsHappen()
        {
            while (true)
            {
                try
                {
                    var rentalCarSvc = new RentalCarService();
                    var rentalCarInfo = await rentalCarSvc.GetCarInfo(_config.HotWireApi.Key, _config.SearchCriteria);

                    Console.WriteLine($"Hotwire API Request Status: {rentalCarInfo.StatusDesc}");

                    var vehicleType = rentalCarInfo.Result.Where(x => x.CarTypeCode == _config.SearchCriteria.VehicleType).ToList();
                    ActOnResults(_config.SearchCriteria.VehicleTypeName, vehicleType);

                    Thread.Sleep(600000); // sleep 10 mins
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An Exception Happened: {ex}");
                }
            }
        }

        private static void ActOnResults(string vehicleType, IEnumerable<RentalCarResult> rentals)
        {
            foreach (var vehicle in rentals)
            {
                var timestamp = DateTime.Now.ToString("G");

                Console.ForegroundColor = ConsoleColor.White;
                if (Double.Parse(vehicle.DailyRate) > Double.Parse(_config.SearchCriteria.MaxDailyRate))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    var emailTemplate = $"[{timestamp}] {vehicleType} - Daily Rate: ${vehicle.DailyRate}, SubTotal: ${vehicle.SubTotal}, Total Price: ${vehicle.TotalPrice}\n {vehicle.DeepLink}";
                    Emailer.Send(_config, emailTemplate);
                }
                Console.WriteLine($"[{timestamp}] {vehicleType} - Daily Rate: ${vehicle.DailyRate}, SubTotal: ${vehicle.SubTotal}, Total Price: ${vehicle.TotalPrice}");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
