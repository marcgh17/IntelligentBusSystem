using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentBusSystem.Models
{
    public class StudentProfileModel
    {
        public Student Student { get; set; }
        public Class StudentClass { get; set; }
        public List<Address> StudentAddresses { get; set; }
        public List<Subscription> StudentSubscriptions { get; set; }


    }
}