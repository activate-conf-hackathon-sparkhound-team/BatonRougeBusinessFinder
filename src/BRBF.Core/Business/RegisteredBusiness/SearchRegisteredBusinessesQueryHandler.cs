using BRBF.Core.Framework;
using BRBF.Core.Framework.RequestPipeline;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.Core.Business.RegisteredBusiness
{
    public class SearchRegisteredBusinessesQueryHandler
        : IQueryHandler<SearchRegisteredBusinessesQueryRequest, PagedResponseDto<RegisteredBusinessDto>>
    {
        public SearchRegisteredBusinessesQueryHandler(IRegisteredBusinessRepository registeredBusinessRepository)
        {
            RegisteredBusinessRepository = registeredBusinessRepository;
        }

        public IRegisteredBusinessRepository RegisteredBusinessRepository { get; }

        public async Task<PagedResponseDto<RegisteredBusinessDto>> Handle(
            SearchRegisteredBusinessesQueryRequest request, 
            CancellationToken cancellationToken
            )
        {
            var result = await RegisteredBusinessRepository.SearchRegisteredBusinesses(request);
            return result;
        }
    }
}
