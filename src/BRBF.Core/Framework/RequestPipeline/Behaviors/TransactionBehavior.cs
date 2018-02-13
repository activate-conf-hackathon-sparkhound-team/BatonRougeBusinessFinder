using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.Core.Framework.RequestPipeline.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
    {
        public TransactionBehavior(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public async Task<TResponse> Handle(
            TRequest request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next
            )
        {
            await UnitOfWork.BeginTransactionAsync(IsolationLevel.ReadUncommitted, cancellationToken);
            var response = await next();
            var count = await UnitOfWork.CommitAsync(cancellationToken);
            return response;
        }
    }
}
