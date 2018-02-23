using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BRBF.Core.Business.Notifications
{
    public interface IEmailService
    {
        Task SendEmail(string toEmail, string subject, string body);
    }
}
