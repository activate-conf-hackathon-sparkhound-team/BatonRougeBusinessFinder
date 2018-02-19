using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.Core.Framework
{
    public interface IUnitOfWork
    {
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted);
        Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted, CancellationToken cancellationToken = default(CancellationToken));
        int Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
        int SavePendingChangesWithoutCommit();
        Task<int> SavePendingChangesWithoutCommitAsync(CancellationToken cancellationToken = default(CancellationToken));
        void Rollback();
    }
}
