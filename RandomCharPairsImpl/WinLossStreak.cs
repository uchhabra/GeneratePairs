using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace RandomCharPairsImpl
{
    [JsonObject]
    public class Letters
    {
        [JsonProperty]
        public int wins { get; set; }
        
        [JsonProperty]
        public int streak { get; set; }
    }

    [JsonObject]
    public class Numbers
    {
        [JsonProperty]
        public int wins { get; set; }

        [JsonProperty]
        public int streak { get; set; }
    }

    public class RootObject
    {
        [JsonProperty]
        public Letters letters { get; set; }

        [JsonProperty]
        public Numbers numbers { get; set; }
    }
}
