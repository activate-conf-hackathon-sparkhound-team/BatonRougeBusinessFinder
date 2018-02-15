using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.DataAccess.Repositories
{
    public abstract class BaseRepository
    {
        public BaseRepository(BatonRougeBusinessFinderDbContext context)
        {
            Context = context;
        }

        public BatonRougeBusinessFinderDbContext Context { get; }
    }
}
