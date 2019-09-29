using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace clod_rest_server
{
    public class ServerInformation
    {
        public String Version { get; } = "0.1";
        public long Timestamp { get; } = DateTime.Now.Ticks;
        //public Dictionary<string, double?> PlaneInformation { get; set; }
        public Object PlaneInformation { get; set; }

    }
}
