using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Framework
{
    public class PagedRequestDto<TRequestData> : IDto
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public TRequestData RequestData { get; set; }
    }
}
