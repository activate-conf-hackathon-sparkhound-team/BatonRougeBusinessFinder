using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Framework
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
