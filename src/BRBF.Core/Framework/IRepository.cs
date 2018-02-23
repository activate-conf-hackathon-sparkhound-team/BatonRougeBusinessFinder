using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRBF.Core.Framework
{
    public interface IRepository
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
        void AddRange<TEntity>(TEntity entity) where TEntity : class;
        Task AddRangeAsync<TEntity>(TEntity entity) where TEntity : class;
    }
}
