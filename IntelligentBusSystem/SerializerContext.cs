using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentBusSystem
{
    public class SerializerContext:IntelligentBusSystem.Models.IntelligentBusSystemEntities
    {
        public SerializerContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}