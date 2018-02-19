using BRBF.Core.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Business.Import
{
    public class GeolocationDto : IDto
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("coordinates")]
        public IEnumerable<decimal> Coordinates { get; set; }

        public override string ToString()
        {
            return $"{Type?.Trim()} ({string.Join(", ", Coordinates)})";
        }
    }
}
