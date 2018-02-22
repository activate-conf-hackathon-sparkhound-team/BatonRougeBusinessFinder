using BRBF.Core.Framework;
using BRBF.Core.Framework.RequestPipeline;
using System.Collections.Generic;

namespace BRBF.Core.Business.RegisteredBusiness
{
    public class SearchRegisteredBusinessesQueryRequest 
        : PagedRequestDto<string>, IQuery<PagedResponseDto<RegisteredBusinessDto>>
    {
    }
}