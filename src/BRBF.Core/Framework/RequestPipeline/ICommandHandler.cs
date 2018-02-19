using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Framework.RequestPipeline
{
    public interface ICommandHandler<in TCommand> 
        : IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }
}
