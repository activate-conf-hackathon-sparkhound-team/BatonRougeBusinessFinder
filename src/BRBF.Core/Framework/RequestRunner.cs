using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.Core.Framework
{
    public class RequestRunner : IRequestRunner
    {
        protected ILogger<RequestRunner> Logger { get; }
        protected IMediator Mediator { get; }
        protected IRequestHandlerTypeProvider RequestTypeProvider { get; }

        public RequestRunner(ILogger<RequestRunner> logger, IMediator mediator, IRequestHandlerTypeProvider requestTypeProvider)
        {
            Logger = logger;
            Mediator = mediator;
            RequestTypeProvider = requestTypeProvider;
        }

        /// <summary> 
        /// Executes a given command by name.
        /// </summary>
        /// <code>
        ///   var commandRunner = Container.GetInstance<ICommandRunner>();
        ///   var response = commandRunner.Execute("GetUserCommandRequest", "{'Id':2}");
        /// </code>
        public object Execute(string commandName, string jsonInput)
        {
            // Find the types of the Request/Response.
            var (requestType, responseType) = RequestTypeProvider.GetInputOutputTypes(commandName);

            // Deserialize the Request object from the JSON payload.
            var command = JsonConvert.DeserializeObject(jsonInput, requestType);

            // Get the method for invoking the command.
            var method = Mediator.GetType().GetMethods().Single(m => m.Name == nameof(Mediator.Send) && m.IsGenericMethodDefinition);
            var genericMethod = method.MakeGenericMethod(responseType);

            // Invoke the command.
            var response = genericMethod.Invoke(Mediator, new object[] { command, default(CancellationToken) });

            // Wait for completion.
            var waitMethod = typeof(Task<>).GetMethod(nameof(Task.Wait), new Type[] { });
            waitMethod.Invoke(response, new object[] { });

            // Get Result.
            var resultProperty = response.GetType().GetProperty(nameof(Task<object>.Result));
            object result = resultProperty.GetValue(response);

            // Return Result.
            return result;
        }

        public TResponse Execute<TResponse>(IRequest<TResponse> request)
        {
            var response = ExecuteAsync(request);
            response.Wait();
            return response.Result;
        }

        public Task<TResponse> ExecuteAsync<TResponse>(IRequest<TResponse> request)
        {
            var response = Mediator.Send(request);
            return response;
        }
    }
}
