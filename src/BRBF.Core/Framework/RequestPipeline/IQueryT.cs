using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Framework.RequestPipeline
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
