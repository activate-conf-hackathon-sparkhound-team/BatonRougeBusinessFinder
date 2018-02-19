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
        public SearchRegisteredBusinessesQueryHandler(ISearchRepository searchRepository)
        {
            SearchRepository = searchRepository;
        }

        public ISearchRepository SearchRepository { get; }

        public async Task<PagedResponseDto<RegisteredBusinessDto>> Handle(
            SearchRegisteredBusinessesQueryRequest request, 
            CancellationToken cancellationToken
            )
        {
            var result = await SearchRepository.SearchRegisteredBusinesses(request);
            return result;
        }
    }
}
