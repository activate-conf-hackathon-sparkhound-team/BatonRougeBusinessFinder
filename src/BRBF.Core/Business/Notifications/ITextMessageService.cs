using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Business.Notifications
{
    public interface ITextMessageService
    {
        void SendTextMessage(string toPhoneNumber, string message);
    }
}
