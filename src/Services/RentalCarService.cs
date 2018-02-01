using HotwireCarStalker.Model.Contracts;
using Newtonsoft.Json;

using HotwireCarStalker.Util;
using System;
using System.Threading.Tasks;
using HotwireCarStalker.Configuration;

namespace HotwireCarStalker.Services
{
    public class RentalCarService
    {
        public RentalCarService()
        { }

        public async Task<RentalCarApiResponse> GetCarInfo(string apiKey, SearchCriteria searchCriteria)
        {
            var url = HotwireApiUrlBuilder.BuildRentalCarSearchApi(
                        apiKey,
                        searchCriteria.PickupDate,
                        searchCriteria.PickupTime,
                        searchCriteria.DropoffDate,
                        searchCriteria.DropoffTime,
                        searchCriteria.AirportCode);

            var json = await ApiClient.GetAsync(url);
            var response = JsonConvert.DeserializeObject<RentalCarApiResponse>(json);
            return response;
        }
    }
}