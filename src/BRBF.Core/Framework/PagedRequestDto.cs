using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Framework
{
    public class PagedRequestDto<TRequestData>
    {
        public TRequestData Data { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
