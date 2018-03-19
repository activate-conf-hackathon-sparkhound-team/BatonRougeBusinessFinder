using BRBF.Core.Entities;
using BRBF.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.Core.Business.RegisteredBusiness
{
    public interface IRegisteredBusinessRepository : IRepository
    {
        Task<IEnumerable<RegisteredBusinessDto>> SearchAllRegisteredBusinessesAsync(string searchText, IEnumerable<string> accountNumbers, CancellationToken cancellationToken = default(CancellationToken));
        Task<PagedResponseDto<RegisteredBusinessDto>> SearchRegisteredBusinessesAsync(PagedRequestDto<string> searchText, CancellationToken cancellationToken = default(CancellationToken));
        Task<RegisteredBusinessDto> GetRegisteredBusinessByAccountNumberAsync(string accountNumber, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<NotificationRegistration>> GetNotificationRegistrationsForEmailAsync(string email, CancellationToken cancellationToken = default(CancellationToken));
    }
}
