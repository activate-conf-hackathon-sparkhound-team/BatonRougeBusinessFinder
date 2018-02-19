using BRBF.Core.Business.Search;
using BRBF.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRBF.DataAccess.Repositories
{
    public class SearchRepository : BaseRepository
    {
        public SearchRepository(BatonRougeBusinessFinderDbContext context) 
            : base(context)
        {
        }

        public PagedResponseDto<RegisteredBusinessDto> SearchRegisteredBusinesses(PagedRequestDto<string> searchText)
        {
            var query = (
                from rb in Context.RegisteredBusinesses
                where rb.AccountName.Contains(searchText.Data)
                    || rb.LegalName.Contains(searchText.Data)
                select rb
                );
            var totalCount = query.Count();

            // Ensure Realistic Page Parameters.
            searchText.PageNumber = Math.Max(searchText.PageNumber, 0);
            searchText.PageSize = Math.Max(searchText.PageSize, 1);
            var itemsToSkip = searchText.PageNumber * searchText.PageSize;
            if (itemsToSkip >= totalCount)
            {
                itemsToSkip = Math.Max(itemsToSkip - searchText.PageSize, 0);
            }

            var data = query.Skip(itemsToSkip).Take(searchText.PageSize).ToList()
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

            return new PagedResponseDto<RegisteredBusinessDto>(data, totalCount, searchText.PageSize, searchText.PageNumber);
        }
    }
}
