using System;
using System.Collections.Generic;
using Weapsy.Infrastructure.Domain;
using Weapsy.Domain.Sites.Commands;

namespace Weapsy.Domain.Sites.Handlers
{
    public class DeleteSiteHandler : ICommandHandler<DeleteSite>
    {
        private readonly ISiteRepository _siteRepository;

        public DeleteSiteHandler(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public ICollection<IEvent> Handle(DeleteSite command)
        {
            var site = _siteRepository.GetById(command.Id);

            if (site == null)
                throw new Exception("Site not found.");

            site.Delete();

            _siteRepository.Update(site);

            return site.Events;
        }
    }
}
