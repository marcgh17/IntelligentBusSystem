using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentBusSystem.Models
{
    public class StudentProfileModel
    {
        public Student student { get; set; }
        public Class studentclass { get; set; }
        public List<Address> studentaddresses { get; set; }
    }
}