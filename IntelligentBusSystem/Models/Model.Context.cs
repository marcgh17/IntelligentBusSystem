﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IntelligentBusSystemEntities : DbContext
    {
        public IntelligentBusSystemEntities()
            : base("name=IntelligentBusSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<DailyTrip> DailyTrips { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduledTrip> ScheduledTrips { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentDailyTrip> StudentDailyTrips { get; set; }
        public virtual DbSet<StudentScheduledTrip> StudentScheduledTrips { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<SUser> SUsers { get; set; }
        public virtual DbSet<TripCategory> TripCategories { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<WebAppMenu> WebAppMenus { get; set; }
    }
}
