using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.Core.Framework.RequestPipeline.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> :
        //IRequestPreProcessor<TRequest>,
        //IRequestPostProcessor<TRequest, TResponse>
        IPipelineBehavior<TRequest, TResponse>
    {
        public ILogger<LoggingBehavior<TRequest, TResponse>> Logger { get; }

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            Logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var response = await next();
            Logger.LogInformation($"Handled {typeof(TResponse).Name}");
            return response;
        }

        //public async Task Process(TRequest request)
        //{
        //    Logger.LogInformation($"Handling {typeof(TRequest).Name}");
        //}

        //public async Task Process(TRequest request, TResponse response)
        //{
        //    Logger.LogInformation($"Handled {typeof(TResponse).Name}");
        //}
    }
}
