using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Framework
{
    public interface ICommandHandler<in TCommand> 
        : IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }
}
