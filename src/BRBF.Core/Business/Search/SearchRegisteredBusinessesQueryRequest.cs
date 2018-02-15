using BRBF.Core.Framework;
using BRBF.Core.Framework.RequestPipeline;
using System.Collections.Generic;

namespace BRBF.Core.Business.Search
{
    public class SearchRegisteredBusinessesQueryRequest : IQuery<PagedResponseDto<RegisteredBusinessDto>>
    {
        public string SearchText { get; set; }
    }
}