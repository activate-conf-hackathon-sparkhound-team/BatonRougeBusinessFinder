using BRBF.Core.Business.Import;
using BRBF.Core.Entities;
using BRBF.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SODA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.DataAccess.Services
{
    public class ImportDataService : BaseRepository, IImportDataService
    {
        public ImportDataService(BatonRougeBusinessFinderDbContext context)
            : base(context)
        {
        }

        public async Task<bool> Import(CancellationToken cancellationToken = default(CancellationToken))
        {
            var allRegisteredBusinesses = await Context.RegisteredBusinesses
                .ToDictionaryAsync(x => x.AccountNumber, cancellationToken);

            var client = new SODA.SodaClient("https://data.brla.gov");
            //var rows = client.Query<RegisteredBusinessDto>(new SoqlQuery().Limit(100).Offset(100), "6afw-h38f");
            var resource = client.GetResource<RegisteredBusinessDto>("6afw-h38f");            
            var metadata = client.GetMetadata("6afw-h38f");
            var columns = metadata.Columns.ToList();
            var rows = resource.GetRows();

            foreach (var row in rows)
            {
                if (!allRegisteredBusinesses.TryGetValue(row.AccountNumber, out RegisteredBusiness entity))
                {
                    // Create a new entity.
                    entity = new Core.Entities.RegisteredBusiness();
                    Context.RegisteredBusinesses.Add(entity);
                    allRegisteredBusinesses.Add(row.AccountNumber, entity);
                }

                entity.ABCStatus = row.ABCStatus;
                entity.ABCStatusCode = row.ABCStatusCode;
                entity.AccountLocation = row.AccountLocation;
                entity.AccountLocationCode = row.AccountLocationCode;
                entity.AccountName = row.AccountName;
                entity.AccountNumber = row.AccountNumber.ToString();
                entity.AccountType = row.AccountType;
                entity.AccountTypeCode = row.AccountTypeCode;
                entity.BusinessCloseDate = row.BusinessCloseDate;
                entity.BusinessOpenDate = row.BusinessOpenDate;
                entity.BusinessStatus = row.BusinessStatus;
                entity.ConsolidatedFiler = bool.TryParse(row.ConsolidatedFiler, out var consolidatedFiler) ? (bool?)consolidatedFiler : null;
                entity.ContactPerson = row.ContactPerson;
                entity.Geolocation = row.Geolocation?.ToString();
                entity.LegalName = row.LegalName;
                entity.MailingAddressCity = row.MailingAddressCity;
                entity.MailingAddressLine1 = row.MailingAddressLine1;
                entity.MailingAddressLine2 = row.MailingAddressLine2;
                entity.MailingAddressState = row.MailingAddressState;
                entity.MailingAddressZipCode = row.MailingAddressZipCode;
                entity.NAICSCategory = row.NAICSCategory;
                entity.NAICSCode = row.NAICSCode;
                entity.NAICSGroup = row.NAICSGroup;
                entity.OwnershipType = row.OwnershipType;
                entity.PhysicalAddressCity = row.PhysicalAddressCity;
                entity.PhysicalAddressLine1 = row.PhysicalAddressLine1;
                entity.PhysicalAddressLine2 = row.PhysicalAddressLine2;
                entity.PhysicalAddressState = row.PhysicalAddressState;
                entity.PhysicalAddressZipCode = row.PhysicalAddressZipCode;                
            }

            var itemsChanged = await Context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
