using BRBF.Core.Business.Search;
using BRBF.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRBF.DataAccess.Repositories
{
    public class SearchRepository : BaseRepository, ISearchRepository
    {
        public SearchRepository(BatonRougeBusinessFinderDbContext context) 
            : base(context)
        {
        }

        public async Task<PagedResponseDto<RegisteredBusinessDto>> SearchRegisteredBusinesses(PagedRequestDto<string> searchText)
        {
            const int defaultPageNumber = 1;
            const int defaultPageSize = 25;

            if (searchText == null)
            {
                searchText = new PagedRequestDto<string>()
                {
                    Data = "",
                    PageNumber = defaultPageNumber,
                    PageSize = defaultPageSize,
                };
            }
            else
            {
                if (string.IsNullOrWhiteSpace(searchText.Data))
                {
                    searchText.Data = "";
                }
            }

            int pageNumber = searchText.PageNumber ?? defaultPageNumber;
            int pageSize = searchText.PageSize ?? defaultPageSize;

            var query = (
                from rb in Context.RegisteredBusinesses
                where rb.AccountName.Contains(searchText.Data)
                    || rb.LegalName.Contains(searchText.Data)
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
