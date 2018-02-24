using BRBF.Core;
using BRBF.Core.Business.Notifications;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BRBF.DataAccess.Services
{
    public class EmailService : IEmailService
    {
        public EmailService(IOptions<AppSettings> options)
        {
            AppSettings = options.Value;
        }

        public AppSettings AppSettings { get; }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var server = AppSettings.Smtp.Server ?? "localhost";
            var port = AppSettings.Smtp.Port ?? 587;
            var username = AppSettings.Smtp.UserName;
            var password = AppSettings.Smtp.Password;
            var from = AppSettings.Smtp.From;
            if (!Enum.TryParse<SmtpDeliveryMethod>(AppSettings.Smtp.DeliveryMethod, false, out var deliveryMethod))
            {
                deliveryMethod = SmtpDeliveryMethod.Network;
            }

            SmtpClient client = new SmtpClient(server);
            if (deliveryMethod == SmtpDeliveryMethod.SpecifiedPickupDirectory)
            {
                client.EnableSsl = false;
                client.UseDefaultCredentials = true;
                client.PickupDirectoryLocation = AppSettings.Smtp.PickupDirectoryLocation ?? "C:/Emails";
            }
            else
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Port = port;
                client.Credentials = new NetworkCredential(username, password);
            }


            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(from);
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            await client.SendMailAsync(mailMessage);
        }
    }
}
