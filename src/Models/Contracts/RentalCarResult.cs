namespace HotwireCarStalker.Model.Contracts
{
    public class RentalCarResult
    {
        public string CurrencyCode { get; set; }
        public string DeepLink { get; set; }
        public string ResultId { get; set; }
        public string HWRefNumber { get; set; }
        public string SubTotal { get; set; }
        public string TaxesAndFees { get; set; }
        public string TotalPrice { get; set; }
        public string CarTypeCode { get; set; }
        public string DailyRate { get; set; }
        public string DropoffDay { get; set; }
        public string DropoffTime { get; set; }
        public string PickupDay { get; set; }
        public string PickupTime { get; set; }
        public string LocationDescription { get; set; }
        public string MileageDescription { get; set; }
        public string PickupAirport { get; set; }
        public string RentalDays { get; set; }
        public string VendorLocationId { get; set; }
    }
}