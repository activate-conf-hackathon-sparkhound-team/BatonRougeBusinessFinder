using BRBF.Core.Business.RegisteredBusiness;
using BRBF.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRBF.DataAccess.Repositories
{
    public class RegisteredBusinessRepository : BaseRepository, IRegisteredBusinessRepository
    {
        public RegisteredBusinessRepository(BatonRougeBusinessFinderDbContext context) 
            : base(context)
        {
        }

        public async Task<RegisteredBusinessDto> GetRegisteredBusinessByAccountNumber(string accountNumber)
        {
            accountNumber = accountNumber?.Trim();
            var entity = await Context.RegisteredBusinesses.ToAsyncEnumerable().SingleOrDefault(b => b.AccountNumber == accountNumber);
            var dto = new RegisteredBusinessDto(
                entity.AccountNumber,
                entity.AccountName,
                entity.LegalName,
                entity.AccountLocationCode,
                entity.AccountLocation,
                entity.ContactPerson,
                entity.BusinessOpenDate,
                entity.BusinessStatus,
                entity.BusinessCloseDate,
                entity.OwnershipType,
                entity.AccountTypeCode,
                entity.AccountType,
                entity.NAICSCode,
                entity.NAICSCategory,
                entity.NAICSGroup,
                entity.ABCStatusCode,
                entity.ABCStatus,
                entity.ConsolidatedFiler,
                entity.MailingAddressLine1,
                entity.MailingAddressLine2,
                entity.MailingAddressCity,
                entity.MailingAddressState,
                entity.MailingAddressZipCode,
                entity.PhysicalAddressLine1,
                entity.PhysicalAddressLine2,
                entity.PhysicalAddressCity,
                entity.PhysicalAddressState,
                entity.PhysicalAddressZipCode,
                entity.Geolocation
                );
            return dto;
        }

        public async Task<PagedResponseDto<RegisteredBusinessDto>> SearchRegisteredBusinesses(PagedRequestDto<string> searchText)
        {
            const int defaultPageNumber = 1;
            const int defaultPageSize = 25;

            if (searchText == null)
            {
                searchText = new PagedRequestDto<string>()
                {
                    RequestData = "",
                    PageNumber = defaultPageNumber,
                    PageSize = defaultPageSize,
                };
            }
            else
            {
                if (string.IsNullOrWhiteSpace(searchText.RequestData))
                {
                    searchText.RequestData = "";
                }
            }

            int pageNumber = searchText.PageNumber ?? defaultPageNumber;
            int pageSize = searchText.PageSize ?? defaultPageSize;

            var query = (
                from rb in Context.RegisteredBusinesses
                where rb.AccountName.Contains(searchText.RequestData)
                    || rb.LegalName.Contains(searchText.RequestData)
                select rb
                );
            var totalCount = await query.ToAsyncEnumerable().Count();

            // Ensure Realistic Page Parameters.
            searchText.PageNumber = Math.Max(pageNumber, 0);
            searchText.PageSize = Math.Max(pageSize, 1);
            var itemsToSkip = pageNumber * pageSize;
            if (itemsToSkip >= totalCount)
            {
                itemsToSkip = Math.Max(itemsToSkip - pageSize, 0);
            }

            var list = await query
                .Skip(itemsToSkip)
                .Take(searchText?.PageSize ?? defaultPageSize)
                .ToAsyncEnumerable()
                .ToList();
            var data = list
                .Select(x => new RegisteredBusinessDto(
                    x.AccountNumber,
                    x.AccountName,
                    x.LegalName,
                    x.AccountLocationCode,
                    x.AccountLocation,
                    x.ContactPerson,
                    x.BusinessOpenDate,
                    x.BusinessStatus,
                    x.BusinessCloseDate,
                    x.OwnershipType,
                    x.AccountTypeCode,
                    x.AccountType,
                    x.NAICSCode,
                    x.NAICSCategory,
                    x.NAICSGroup,
                    x.ABCStatusCode,
                    x.ABCStatus,
                    x.ConsolidatedFiler,
                    x.MailingAddressLine1,
                    x.MailingAddressLine2,
                    x.MailingAddressCity,
                    x.MailingAddressState,
                    x.MailingAddressZipCode,
                    x.PhysicalAddressLine1,
                    x.PhysicalAddressLine2,
                    x.PhysicalAddressCity,
                    x.PhysicalAddressState,
                    x.PhysicalAddressZipCode,
                    x.Geolocation
                    ))
                .ToList();

            return new PagedResponseDto<RegisteredBusinessDto>(pageSize, pageNumber, totalCount, data);
        }
    }
}
