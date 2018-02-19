using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.Core.Business.Import
{
    public interface IImportDataService
    {
        Task<bool> Import(CancellationToken cancellationToken = default(CancellationToken));
    }
}
