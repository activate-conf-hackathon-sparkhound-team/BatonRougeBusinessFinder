using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BRBF.Core.Entities
{
    [Table(nameof(RegisteredBusiness))]
    public class RegisteredBusiness
    {
        [Key]
        /// <summary>
        /// Primary Key.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Account number of taxpayer.
        /// </summary>
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        /// <summary>
        /// Legal name of business.
        /// </summary>
        public string LegalName { get; set; }
        public string AccountLocationCode { get; set; }
        public string AccountLocation { get; set; }
        public string ContactPerson { get; set; }
        public DateTime? BusinessOpenDate { get; set; }
        /// <summary>
        /// Business status (O - Open or C - Closed).
        /// </summary>
        public string BusinessStatus { get; set; }
        /// <summary>
        /// Date business closed, only applicable if Business Status = C.
        /// </summary>
        public DateTime? BusinessCloseDate { get; set; }
        public string OwnershipType { get; set; }
        public string AccountTypeCode { get; set; }
        public string AccountType { get; set; }
        /// <summary>
        /// North American Industry Classification System Code.
        /// </summary>
        public string NAICSCode { get; set; }
        /// <summary>
        /// Description of the NAICS Code.
        /// </summary>
        public string NAICSCategory { get; set; }
        /// <summary>
        /// General group for the NAICS Code.
        /// </summary>
        public string NAICSGroup { get; set; }
        public string ABCStatusCode { get; set; }
        public string ABCStatus { get; set; }
        /// <summary>
        /// Indicates whether the business is filing as consolidated (1 = Yes, 0 = No).
        /// </summary>
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

    }
}
