using BRBF.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRBF.DataAccess.Repositories
{
    public abstract class BaseRepository : IRepository
    {
        public BaseRepository(BatonRougeBusinessFinderDbContext context)
        {
            Context = context;
        }

        public BatonRougeBusinessFinderDbContext Context { get; }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            var entityEntry = Context.Add(entity);
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            var entityEntry = await Context.AddAsync<TEntity>(entity);
        }

        public void AddRange<TEntity>(TEntity entity) where TEntity : class
        {
            Context.AddRange(entity);
        }

        public async Task AddRangeAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await Context.AddRangeAsync(entity);
        }
    }
}
