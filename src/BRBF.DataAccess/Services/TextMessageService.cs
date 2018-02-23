using BRBF.Core;
using BRBF.Core.Business.Notifications;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace BRBF.DataAccess.Services
{
    public class TextMessageService : ITextMessageService
    {
        public TextMessageService(
            IOptions<AppSettings> options
            )
        {
            AppSettings = options.Value;
        }

        public AppSettings AppSettings { get; }

        public void SendTextMessage(string toPhoneNumber, string message)
        {
            var accountSid = AppSettings.Twilio.AccountSid;
            var authToken = AppSettings.Twilio.AuthToken;
            var fromPhoneNumber = AppSettings.Twilio.PhoneNumber;

            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(toPhoneNumber);
            var from = new PhoneNumber(fromPhoneNumber);
            var m = MessageResource.Create(
                to,
                from: from,
                body: message
                );

            // log m.Sid;
        }
    }
}
