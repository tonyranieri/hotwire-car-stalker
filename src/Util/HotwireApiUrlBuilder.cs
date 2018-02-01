namespace HotwireCarStalker.Util
{
    public static class HotwireApiUrlBuilder
    {
        public static string BuildRentalCarSearchApi(string apiKey, string pickupDate, string pickupTime, string dropoffDate, string dropoffTime, string location)
        {
            return $"https://api.hotwire.com/v1/search/car?apikey={apiKey}&dest={location}&startdate={pickupDate}&enddate={dropoffDate}&pickuptime={pickupTime}&dropofftime={dropoffTime}&format=json";
        }
    }
}