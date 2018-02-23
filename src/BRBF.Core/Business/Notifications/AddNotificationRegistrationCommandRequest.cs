using BRBF.Core.Framework.RequestPipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Business.Notifications
{
    public class AddNotificationRegistrationCommandRequest : ICommand<bool>
    {
        public string Email { get; set; }
        public string SearchText { get; set; }
        public bool? NotifyOnOpen { get; set; }
        public bool? NotifyOnClose { get; set; }
        public bool? NotifyOnModified { get; set; }
    }
}
