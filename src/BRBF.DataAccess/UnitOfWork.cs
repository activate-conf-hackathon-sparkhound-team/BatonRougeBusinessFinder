using BRBF.Core.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(BatonRougeBusinessFinderDbContext context)
        {
            Context = context;
        }

        public BatonRougeBusinessFinderDbContext Context { get; }
        public IDbContextTransaction DbContextTransaction => Context.Database.CurrentTransaction;

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
        {
            var transaction = Context.Database.BeginTransaction(isolationLevel);
        }

        public async Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Context.Database.BeginTransactionAsync(cancellationToken);
        }

        public int Commit()
        {
            var count = Context.SaveChanges();
            Context.Database.CommitTransaction();
            return count;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var count = await Context.SaveChangesAsync(cancellationToken);
            Context.Database.CommitTransaction();
            return count;
        }

        public int SavePendingChangesWithoutCommit()
        {
            var count = Context.SaveChanges();
            return count;
        }

        public async Task<int> SavePendingChangesWithoutCommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var count = await Context.SaveChangesAsync(cancellationToken);
            return count;
        }

        public void Rollback()
        {
            Context.Database.RollbackTransaction();
        }
    }
}
