using System;
using System.Collections.Generic;

namespace ProductToPricing.Models
{
    public partial class RegularlyScheduledTime
    {
        public DateTime FromDate { get; set; }
        public int TravelProductId { get; set; }
        public int DayIdOfferedArriving { get; set; }
        public int DayIdOfferedDeparting { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public DateTime ThruDate { get; set; }

        public virtual DayOfTheWeek DayIdOfferedArrivingNavigation { get; set; } = null!;
        public virtual DayOfTheWeek DayIdOfferedDepartingNavigation { get; set; } = null!;
        public virtual TravelProduct TravelProduct { get; set; } = null!;
    }
}
