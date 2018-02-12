using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRBF.Core.Framework
{
    public interface IRequestRunner
    {
        object Execute(string commandName, string jsonInput);
        TResponse Execute<TResponse>(IRequest<TResponse> request);
        Task<TResponse> ExecuteAsync<TResponse>(IRequest<TResponse> request);
    }
}
