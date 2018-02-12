using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BRBF.Core.Framework
{
    public class RequestHandlerTypeProvider : IRequestHandlerTypeProvider
    {
        protected IDictionary<string, Type> RequestTypes { get; } 

        public RequestHandlerTypeProvider()
        {
            var assembly = typeof(RequestHandlerTypeProvider).GetTypeInfo().Assembly;
            var assemblyTypes = assembly.GetTypes();
            var commandTypes = assemblyTypes.Where(t => typeof(ICommand).IsAssignableFrom(t.GetType()));
            var commandTTypes = assemblyTypes.Where(t => t.GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommand<>)));
            var queryTypes = assemblyTypes.Where(t => typeof(IQuery).IsAssignableFrom(t.GetType()));
            var queryTTypes = assemblyTypes.Where(t => t.GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IQuery<>)));

            RequestTypes = commandTypes.Concat(commandTTypes).Concat(queryTypes).Concat(queryTTypes).ToDictionary(x => x.Name);
        }

        public Type GetInputType(string requestName)
        {
            if (RequestTypes.TryGetValue(requestName, out var type))
            {
                return type;
            }
            else
            {
                throw new InvalidOperationException($"Unable to find request type for name {requestName}.");
            }
        }

        public (Type requestType, Type responseType) GetInputOutputTypes(string requestName)
        {
            var requestType = GetInputType(requestName);
            var responseType = requestType.GetTypeInfo().GetInterface(typeof(IRequest<>).Name).GetGenericArguments().FirstOrDefault();
            return (requestType, responseType);
        }
    }
}
