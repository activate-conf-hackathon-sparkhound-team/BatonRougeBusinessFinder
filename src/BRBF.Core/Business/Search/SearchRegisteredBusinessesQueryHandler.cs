using BRBF.Core.Framework;
using BRBF.Core.Framework.RequestPipeline;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.Core.Business.Search
{
    public class SearchRegisteredBusinessesQueryHandler
        : IQueryHandler<SearchRegisteredBusinessesQueryRequest, PagedResponseDto<RegisteredBusinessDto>>
    {
        public SearchRegisteredBusinessesQueryHandler()
        {

        }

        public Task<PagedResponseDto<RegisteredBusinessDto>> Handle(
            SearchRegisteredBusinessesQueryRequest request, 
            CancellationToken cancellationToken
            )
        {
            throw new NotImplementedException();
        }
    }
}
