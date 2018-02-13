using BRBF.Core.Business.Import;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.Importer
{
    public class WebJobsMethods
    {
        public IImportDataService ImportDataService { get; }

        public WebJobsMethods(IImportDataService importDataService)
        {
            ImportDataService = importDataService;
        }

        public async Task DoSomethingOnATimer(
            [TimerTrigger("0 0 0 * * *", RunOnStartup = true)] TimerInfo timerInfo, 
            TextWriter log,
            CancellationToken cancellationToken
            )
        {
            var success = await ImportDataService.Import(cancellationToken);
        }

        public async Task DoSomethingOnAQueue(
            [QueueTrigger("baton-rouge-business-finder-import-queue")] int id,
            TextWriter log,
            CancellationToken cancellationToken
            )
        {
            var success = await ImportDataService.Import(cancellationToken);
        }

    }
}
