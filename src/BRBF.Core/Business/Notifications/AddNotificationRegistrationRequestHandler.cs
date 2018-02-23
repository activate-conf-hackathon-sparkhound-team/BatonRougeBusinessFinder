using BRBF.Core.Business.RegisteredBusiness;
using BRBF.Core.Entities;
using BRBF.Core.Framework.RequestPipeline;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRBF.Core.Business.Notifications
{
    public class AddNotificationRegistrationCommandHandler
        : ICommandHandler<AddNotificationRegistrationCommandRequest, bool>
    {
        public AddNotificationRegistrationCommandHandler(IRegisteredBusinessRepository registeredBusinessRepository)
        {
            RegisteredBusinessRepository = registeredBusinessRepository;
        }

        public IRegisteredBusinessRepository RegisteredBusinessRepository { get; }

        public async Task<bool> Handle(
            AddNotificationRegistrationCommandRequest request, 
            CancellationToken cancellationToken
            )
        {
            var currentRegistrations = await RegisteredBusinessRepository.GetNotificationRegistrationsForEmailAsync(request.Email);
            // TODO - limit the number of registrations

            var entity = new NotificationRegistration()
            {
                Email = request.Email,
                SearchText = request.SearchText,
                NotifyOnOpen = request.NotifyOnOpen ?? true,
                NotifyOnClose = request.NotifyOnClose ?? true,
                NotifyOnModified = request.NotifyOnModified ?? true,
            };
            await RegisteredBusinessRepository.AddAsync(entity);

            return true;
        }
    }
}
