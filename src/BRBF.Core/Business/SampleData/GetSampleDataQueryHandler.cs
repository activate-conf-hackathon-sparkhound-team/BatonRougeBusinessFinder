using BRBF.Core.Framework.RequestPipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.Core.Business.SampleData
{
    public class GetSampleDataQueryHandler : IQueryHandler<GetSampleDataQueryRequest, IEnumerable<WeatherForecastDto>>
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public GetSampleDataQueryHandler()
        {
        }

        public async Task<IEnumerable<WeatherForecastDto>> Handle(GetSampleDataQueryRequest request, CancellationToken cancellationToken)
        {
            var rng = new Random();
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
            return forecasts;
        }
    }
}
