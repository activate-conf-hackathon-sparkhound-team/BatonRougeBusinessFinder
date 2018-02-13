using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Importer
{
    public class AppSettings
    {
        public AzureWebJobSettings AzureWebJob { get; set; }

        public class AzureWebJobSettings
        {
            public string QueueName { get; set; }
            public string QueueNamePoison { get; set; }
        }
    }

}
