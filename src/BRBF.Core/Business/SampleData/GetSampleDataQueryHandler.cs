using BRBF.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.Core.Business.SampleData
{
    public class GetSampleDataQueryHandler : IQueryHandler<GetSampleDataQueryRequest, GetSampleDataQueryResponse>
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public GetSampleDataQueryHandler()
        {
        }

        public async Task<GetSampleDataQueryResponse> Handle(GetSampleDataQueryRequest request, CancellationToken cancellationToken)
        {
            var rng = new Random();
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
            var response = new GetSampleDataQueryResponse() { WeatherForecasts = forecasts };
            return response;
        }
    }

    public class GetSampleDataQueryRequest : IQuery<GetSampleDataQueryResponse>
    {

    }

    public class GetSampleDataQueryResponse
    {
        public IEnumerable<WeatherForecastDto> WeatherForecasts { get; set; }
    }

}
