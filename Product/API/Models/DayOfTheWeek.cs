using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class DayOfTheWeek
    {
        public DayOfTheWeek()
        {
            RegularlyScheduledTimeDayIdOfferedArrivingNavigations = new HashSet<RegularlyScheduledTime>();
            RegularlyScheduledTimeDayIdOfferedDepartingNavigations = new HashSet<RegularlyScheduledTime>();
        }

        public int DayOfTheWeekId { get; set; }
        public string DayName { get; set; } = null!;

        public virtual ICollection<RegularlyScheduledTime> RegularlyScheduledTimeDayIdOfferedArrivingNavigations { get; set; }
        public virtual ICollection<RegularlyScheduledTime> RegularlyScheduledTimeDayIdOfferedDepartingNavigations { get; set; }
    }
}
