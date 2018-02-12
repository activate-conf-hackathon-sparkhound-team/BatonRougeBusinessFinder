using BRBF.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Business.SampleData
{
    public class WeatherForecastDto : IDto
    {
        public string DateFormatted { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }

        public int TemperatureF
        {
            get
            {
                return 32 + (int)(TemperatureC / 0.5556);
            }
        }
    }
}
