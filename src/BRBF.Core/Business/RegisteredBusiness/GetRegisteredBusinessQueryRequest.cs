using BRBF.Core.Framework;
using BRBF.Core.Framework.RequestPipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Business.RegisteredBusiness
{
    public class GetRegisteredBusinessQueryRequest : IQuery<RegisteredBusinessDto>
    {
        public string AccountNumber { get; set; }
    }
}
