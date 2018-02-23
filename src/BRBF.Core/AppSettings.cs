using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core
{
    public class AppSettings
    {
        public AzureWebJobSettings AzureWebJob { get; set; }
        public SmtpSettings Smtp { get; set; }
        public TwilioSettings Twilio { get; set; }
        public bool? UseFullTextSearch { get; set; }

        public class AzureWebJobSettings
        {
            public string QueueName { get; set; }
            public string QueueNamePoison { get; set; }
        }

        public class SmtpSettings
        {
            public string Server { get; set; }
            public int? Port { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string From { get; set; }
            public string DeliveryMethod { get; set; }
            public string PickupDirectoryLocation { get; set; }
        }

        public class TwilioSettings
        {
            public string AccountSid { get; set; }
            public string AuthToken { get; set; }
            public string PhoneNumber { get; set; }
        }
    }

}
