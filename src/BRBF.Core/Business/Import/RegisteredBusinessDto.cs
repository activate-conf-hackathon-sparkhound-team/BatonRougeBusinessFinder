using BRBF.Core.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Business.Import
{
    public class RegisteredBusinessDto : IDto
    {
        [JsonProperty("taccount", Required = Required.Default)]
        /// <summary>
        /// Account number of taxpayer.
        /// </summary>
        public string AccountNumber { get; set; }

        [JsonProperty("tname", Required = Required.Default)]
        public string AccountName { get; set; }

        [JsonProperty("tlegalname", Required = Required.Default)]
        /// <summary>
        /// Legal name of business.
        /// </summary>
        public string LegalName { get; set; }

        [JsonProperty("tacctlocation", Required = Required.Default)]
        public string AccountLocationCode { get; set; }

        [JsonProperty("location", Required = Required.Default)]
        public string AccountLocation { get; set; }

        [JsonProperty("tcontactperson", Required = Required.Default)]
        public string ContactPerson { get; set; }

        [JsonProperty("topendate", Required = Required.Default)]
        public DateTime? BusinessOpenDate { get; set; }

        [JsonProperty("tstatus", Required = Required.Default)]
        /// <summary>
        /// Business status (O - Open or C - Closed).
        /// </summary>
        public string BusinessStatus { get; set; }

        [JsonProperty("tclosedate", Required = Required.Default)]
        /// <summary>
        /// Date business closed, only applicable if Business Status = C.
        /// </summary>
        public DateTime? BusinessCloseDate { get; set; }

        [JsonProperty("townership", Required = Required.Default)]
        public string OwnershipType { get; set; }

        [JsonProperty("taccttype", Required = Required.Default)]
        public string AccountTypeCode { get; set; }

        [JsonProperty("typename", Required = Required.Default)]
        public string AccountType { get; set; }

        [JsonProperty("tnaic", Required = Required.Default)]
        /// <summary>
        /// North American Industry Classification System Code.
        /// </summary>
        public string NAICSCode { get; set; }

        [JsonProperty("naicname", Required = Required.Default)]
        /// <summary>
        /// Description of the NAICS Code.
        /// </summary>
        public string NAICSCategory { get; set; }

        [JsonProperty("naicgroupname", Required = Required.Default)]
        /// <summary>
        /// General group for the NAICS Code.
        /// </summary>
        public string NAICSGroup { get; set; }

        [JsonProperty("abcname", Required = Required.Default)]
        public string ABCStatusCode { get; set; }

        [JsonProperty("tabc", Required = Required.Default)]
        public string ABCStatus { get; set; }

        [JsonProperty("consolidated_filer", Required = Required.Default)]
        /// <summary>
        /// Indicates whether the business is filing as consolidated (1 = Yes, 0 = No).
        /// </summary>
        public string ConsolidatedFiler { get; set; }

        [JsonProperty("tmailaddress1", Required = Required.Default)]
        public string MailingAddressLine1 { get; set; }

        [JsonProperty("tmailaddress2", Required = Required.Default)]
        public string MailingAddressLine2 { get; set; }

        [JsonProperty("tmailcity", Required = Required.Default)]
        public string MailingAddressCity { get; set; }

        [JsonProperty("tmailstate", Required = Required.Default)]
        public string MailingAddressState { get; set; }

        [JsonProperty("tmailzipcode5", Required = Required.Default)]
        public string MailingAddressZipCode { get; set; }

        [JsonProperty("tphysicaladdress1", Required = Required.Default)]
        public string PhysicalAddressLine1 { get; set; }

        [JsonProperty("tphysicaladdress2", Required = Required.Default)]
        public string PhysicalAddressLine2 { get; set; }

        [JsonProperty("tphysicalcity", Required = Required.Default)]
        public string PhysicalAddressCity { get; set; }

        [JsonProperty("tphysicalstate", Required = Required.Default)]
        public string PhysicalAddressState { get; set; }

        [JsonProperty("tphysicalzipcode5", Required = Required.Default)]
        public string PhysicalAddressZipCode { get; set; }

        [JsonProperty("geolocation", Required = Required.Default)]
        public GeolocationDto Geolocation { get; set; }
    }
}
