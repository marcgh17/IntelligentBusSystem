//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntelligentBusSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Driver
    {
        public Driver()
        {
            this.DailyTrips = new HashSet<DailyTrip>();
            this.ScheduledTrips = new HashSet<ScheduledTrip>();
        }
    
        public string DriverID { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }
        public string DriverPhoto { get; set; }
        public string DriverThumbPhoto { get; set; }
        public Nullable<double> DriverLat { get; set; }
        public Nullable<double> DriverLong { get; set; }
    
        public virtual ICollection<DailyTrip> DailyTrips { get; set; }
        public virtual ICollection<ScheduledTrip> ScheduledTrips { get; set; }
    }
}
