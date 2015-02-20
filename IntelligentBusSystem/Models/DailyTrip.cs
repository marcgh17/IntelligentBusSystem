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
    
    public partial class DailyTrip
    {
        public DailyTrip()
        {
            this.StudentDailyTrips = new HashSet<StudentDailyTrip>();
        }
    
        public int DailyTripID { get; set; }
        public System.DateTime DailyTripDate { get; set; }
        public Nullable<int> ScheduledTripID { get; set; }
        public int BusID { get; set; }
        public string DriverID { get; set; }
        public Nullable<System.TimeSpan> DailyTripStartTime { get; set; }
        public Nullable<System.TimeSpan> DailyTripEndTime { get; set; }
    
        public virtual Bus Bus { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual ScheduledTrip ScheduledTrip { get; set; }
        public virtual ICollection<StudentDailyTrip> StudentDailyTrips { get; set; }
    }
}
