using System;

namespace Water.Domain
{
    public class WaterTankLevel
    {
        public Guid ID { get; set; }
        public Guid IDArea { get; set; }
        DateTime Date { get; set; }
        double Amount { get; set; }
    }
}
