using BRBF.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Business.RegisteredBusiness
{
    public class RegisteredBusinessDto : IDto
    {
        public string AccountNumber { get; set; }            
        public string AccountName { get; set; }
        public string LegalName { get; set; }
        public string AccountLocationCode { get; set; }
        public string AccountLocation { get; set; }
        public string ContactPerson { get; set; }
        public DateTime? BusinessOpenDate { get; set; }
        public string BusinessStatus { get; set; }
        public DateTime? BusinessCloseDate { get; set; }
        public string OwnershipType { get; set; }
        public string AccountTypeCode { get; set; }
        public string AccountType { get; set; }
        public string NAICSCode { get; set; }
        public string NAICSCategory { get; set; }
        public string NAICSGroup { get; set; }
        public string ABCStatusCode { get; set; }
        public string ABCStatus { get; set; }
        public bool? ConsolidatedFiler { get; set; }
        public string MailingAddressLine1 { get; set; }
        public string MailingAddressLine2 { get; set; }
        public string MailingAddressCity { get; set; }
        public string MailingAddressState { get; set; }
        public string MailingAddressZipCode { get; set; }
        public string PhysicalAddressLine1 { get; set; }
        public string PhysicalAddressLine2 { get; set; }
        public string PhysicalAddressCity { get; set; }
        public string PhysicalAddressState { get; set; }
        public string PhysicalAddressZipCode { get; set; }
        public string Geolocation { get; set; }

        public RegisteredBusinessDto() { }
        public RegisteredBusinessDto(
            string accountNumber,
            string accountName,
            string legalName,
            string accountLocationCode,
            string accountLocation,
            string contactPerson,
            DateTime? businessOpenDate,
            string businessStatus,
            DateTime? businessCloseDate,
            string ownershipType,
            string accountTypeCode,
            string accountType,
            string naicsCode,
            string naicsCategory,
            string naicsGroup,
            string abcStatusCode,
            string abcStatus,
            bool? consolidatedFiler,
            string mailingAddressLine1,
            string mailingAddressLine2,
            string mailingAddressCity,
            string mailingAddressState,
            string mailingAddressZipCode,
            string physicalAddressLine1,
            string physicalAddressLine2,
            string physicalAddressCity,
            string physicalAddressState,
            string physicalAddressZipCode,
            string geolocation
            )
        {
            AccountNumber = accountNumber;
            AccountName = accountName;
            LegalName = legalName;
            AccountLocationCode = accountLocationCode;
            AccountLocation = accountLocation;
            ContactPerson = contactPerson;
            BusinessOpenDate = businessOpenDate;
            BusinessStatus = businessStatus;
            BusinessCloseDate = businessCloseDate;
            OwnershipType = ownershipType;
            AccountTypeCode = accountTypeCode;
            AccountType = accountType;
            NAICSCode = naicsCode;
            NAICSCategory = naicsCategory;
            NAICSGroup = naicsGroup;
            ABCStatusCode = abcStatusCode;
            ABCStatus = abcStatus;
            ConsolidatedFiler = consolidatedFiler;
            MailingAddressLine1 = mailingAddressLine1;
            MailingAddressLine2 = mailingAddressLine2;
            MailingAddressCity = mailingAddressCity;
            MailingAddressState = mailingAddressState;
            MailingAddressZipCode = mailingAddressZipCode;
            PhysicalAddressLine1 = physicalAddressLine1;
            PhysicalAddressLine2 = physicalAddressLine2;
            PhysicalAddressCity = physicalAddressCity;
            PhysicalAddressState = physicalAddressState;
            PhysicalAddressZipCode = physicalAddressZipCode;
            Geolocation = geolocation;
        }
    }
}
