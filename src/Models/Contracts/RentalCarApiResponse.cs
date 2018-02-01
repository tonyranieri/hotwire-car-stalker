using System.Collections.Generic;

namespace HotwireCarStalker.Model.Contracts
{
    public class RentalCarApiResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public MetaData MetaData { get; set; }
        public IEnumerable<RentalCarResult> Result { get; set; }
        public string StatusCode { get; set; }
        public string StatusDesc { get; set; }
    }
}