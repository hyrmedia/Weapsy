using System.Collections.Generic;
using FluentValidation;
using Weapsy.Infrastructure.Domain;
using Weapsy.Domain.Sites.Commands;

namespace Weapsy.Domain.Sites.Handlers
{
    public class CreateSiteHandler : ICommandHandler<CreateSite>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IValidator<CreateSite> _validator;

        public CreateSiteHandler(ISiteRepository siteRepository, IValidator<CreateSite> validator)
        {
            _siteRepository = siteRepository;
            _validator = validator;
        }

        public ICollection<IEvent> Handle(CreateSite command)
        {
            var site = Site.CreateNew(command, _validator);

            _siteRepository.Create(site);

            return site.Events;
        }
    }
}
