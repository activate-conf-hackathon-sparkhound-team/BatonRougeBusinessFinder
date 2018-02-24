using BRBF.Core.Business.Import;
using BRBF.Core.Business.Notifications;
using BRBF.Core.Business.RegisteredBusiness;
using BRBF.Core.Entities;
using BRBF.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public ImportDataService(
            BatonRougeBusinessFinderDbContext context, 
            IEmailService emailService,
            ITextMessageService textMessageService,
            IRegisteredBusinessRepository registeredBusinessRepository,
            ILogger<ImportDataService> logger
            )
            : base(context)
        {
            EmailService = emailService;
            TextMessageService = textMessageService;
            RegisteredBusinessRepository = registeredBusinessRepository;
            Logger = logger;
        }

        public IEmailService EmailService { get; }
        public ITextMessageService TextMessageService { get; }
        public IRegisteredBusinessRepository RegisteredBusinessRepository { get; }
        public ILogger<ImportDataService> Logger { get; }

        public async Task<bool> Import(CancellationToken cancellationToken = default(CancellationToken))
        {
            var allRegisteredBusinesses = await Context.RegisteredBusinesses
                .ToDictionaryAsync(x => x.AccountNumber, cancellationToken);

            var client = new SODA.SodaClient("https://data.brla.gov");
            //var rows = client.Query<RegisteredBusinessDto>(new SoqlQuery().Limit(100).Offset(100), "6afw-h38f");
            var resource = client.GetResource<Core.Business.Import.RegisteredBusinessDto>("6afw-h38f");            
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

            var allEntries = Context.ChangeTracker.Entries<RegisteredBusiness>();
            var added = allEntries.Where(x => x.State == EntityState.Added).ToDictionary(x => x.Entity.AccountNumber, x => x.Entity);
            var modified = allEntries.Where(x => x.State == EntityState.Modified).ToDictionary(x => x.Entity.AccountNumber, x => x.Entity);
            var deleted = allEntries.Where(x => x.State == EntityState.Deleted).ToDictionary(x => x.Entity.AccountNumber, x => x.Entity);

            var addedAccountNumbers = added.Select(x => x.Key).ToList();
            var modifiedAccountNumbers = modified.Select(x => x.Key).ToList();
            var deletedAccountNames = deleted.Select(x => x.Key).ToList();

            // Save changes
            var itemsChanged = await Context.SaveChangesAsync(cancellationToken);

            // Notify people of changes
            var allRegistrations = Context.NotificationRegistrations.ToList();
            
            foreach (var r in allRegistrations)
            {
                try
                {
                    IEnumerable<Core.Business.RegisteredBusiness.RegisteredBusinessDto> addedMatches = new List<Core.Business.RegisteredBusiness.RegisteredBusinessDto>();
                    IEnumerable<Core.Business.RegisteredBusiness.RegisteredBusinessDto> modifiedMatches = new List<Core.Business.RegisteredBusiness.RegisteredBusinessDto>();
                    if (r.NotifyOnOpen)
                    {
                        addedMatches = await RegisteredBusinessRepository.SearchAllRegisteredBusinessesAsync(r.SearchText, addedAccountNumbers);
                    }
                    if (r.NotifyOnModified || r.NotifyOnClose)
                    {
                        modifiedMatches = await RegisteredBusinessRepository.SearchAllRegisteredBusinessesAsync(r.SearchText, modifiedAccountNumbers);
                    }
                    // TODO - handle deletes?

                    if (addedMatches.Any())
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("There are new businesses in Baton Rouge matching your search criteria!");
                        foreach (var m in addedMatches)
                        {
                            sb.AppendLine($"<a href='http://batonrougebusinessfinder.azurewebsites.net/registered-business/{m.AccountNumber}'>{m.AccountName}</a>");
                        }
                        var body = sb.ToString();
                        if (!string.IsNullOrWhiteSpace(r.Email))
                        {
                            await EmailService.SendEmailAsync(r.Email, "New businesses in Baton Rouge!", body);
                        }
                        if (!string.IsNullOrWhiteSpace(r.PhoneNumber))
                        {
                            TextMessageService.SendTextMessage(r.PhoneNumber, body);
                        }
                    }
                    if (modifiedMatches.Any())
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("There are updated businesses in Baton Rouge matching your search criteria!");
                        foreach (var m in modifiedMatches)
                        {
                            sb.AppendLine($"<a href='http://batonrougebusinessfinder.azurewebsites.net/registered-business/{m.AccountNumber}'>{m.AccountName}</a>");
                        }
                        var body = sb.ToString();

                        if (!string.IsNullOrWhiteSpace(r.Email))
                        {
                            await EmailService.SendEmailAsync(r.Email, "Updated businesses in Baton Rouge!", body);
                        }
                        if (!string.IsNullOrWhiteSpace(r.PhoneNumber))
                        {
                            TextMessageService.SendTextMessage(r.PhoneNumber, body);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, ex.Message);
                }
            }

            return true;
        }
    }
}
