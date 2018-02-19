using BRBF.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRBF.Core.Business.Search
{
    public interface ISearchRepository
    {
        Task<PagedResponseDto<RegisteredBusinessDto>> SearchRegisteredBusinesses(PagedRequestDto<string> searchText);
    }
}
