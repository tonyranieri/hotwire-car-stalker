using System.Collections.Generic;

namespace HotwireCarStalker.Model.Contracts
{
    public class CarMetaData
    {
        public IEnumerable<CarType> CarTypes { get; set; }
    }
}