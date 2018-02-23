using BRBF.Core.Entities;
using BRBF.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRBF.Core.Business.RegisteredBusiness
{
    public interface IRegisteredBusinessRepository : IRepository
    {
        Task<PagedResponseDto<RegisteredBusinessDto>> SearchRegisteredBusinessesAsync(PagedRequestDto<string> searchText);
        Task<RegisteredBusinessDto> GetRegisteredBusinessByAccountNumberAsync(string accountNumber);
        Task<IEnumerable<NotificationRegistration>> GetNotificationRegistrationsForEmailAsync(string email);
    }
}
