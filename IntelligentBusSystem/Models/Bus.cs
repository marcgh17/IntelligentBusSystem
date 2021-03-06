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
    
    public partial class Bus
    {
        public Bus()
        {
            this.DailyTrips = new HashSet<DailyTrip>();
            this.ScheduledTrips = new HashSet<ScheduledTrip>();
        }
    
        public int BusID { get; set; }
        public Nullable<int> BusNumber { get; set; }
        public string BusModel { get; set; }
        public int BusCapacity { get; set; }
        public int BusMaxCapacity { get; set; }
        public string BusStatus { get; set; }
        public double BusLat { get; set; }
        public double BusLong { get; set; }
    
        public virtual ICollection<DailyTrip> DailyTrips { get; set; }
        public virtual ICollection<ScheduledTrip> ScheduledTrips { get; set; }
    }
}
