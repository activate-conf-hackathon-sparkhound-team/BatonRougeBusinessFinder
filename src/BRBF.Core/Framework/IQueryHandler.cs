using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Framework
{
    public interface IQueryHandler<in TQuery> 
        : IRequestHandler<TQuery>
        where TQuery : IQuery
    {
    }
}
