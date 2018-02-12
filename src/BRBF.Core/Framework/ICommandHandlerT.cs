using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Framework
{
    public interface ICommandHandler<in TCommand, TResponse> 
        : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}
