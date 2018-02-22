using BRBF.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRBF.Core.Business.RegisteredBusiness
{
    public interface IRegisteredBusinessRepository
    {
        Task<PagedResponseDto<RegisteredBusinessDto>> SearchRegisteredBusinesses(PagedRequestDto<string> searchText);
        Task<RegisteredBusinessDto> GetRegisteredBusinessByAccountNumber(string accountNumber);
    }
}
