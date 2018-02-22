using BRBF.Core.Framework.RequestPipeline;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.Core.Business.RegisteredBusiness
{
    public class GetRegisteredBusinessQueryHandler
        : IQueryHandler<GetRegisteredBusinessQueryRequest, RegisteredBusinessDto>
    {
        public GetRegisteredBusinessQueryHandler(IRegisteredBusinessRepository registeredBusinessRepository)
        {
            RegisteredBusinessRepository = registeredBusinessRepository;
        }

        public IRegisteredBusinessRepository RegisteredBusinessRepository { get; }

        public async Task<RegisteredBusinessDto> Handle(
            GetRegisteredBusinessQueryRequest request, 
            CancellationToken cancellationToken
            )
        {
            var result = await RegisteredBusinessRepository.GetRegisteredBusinessByAccountNumber(request.AccountNumber);
            return result;
        }
    }
}
