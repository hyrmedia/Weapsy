using System.Collections.Generic;
using Weapsy.Infrastructure.Domain;
using Weapsy.Domain.Menus.Commands;
using System;

namespace Weapsy.Domain.Menus.Handlers
{
    public class SetMenuItemPermissionsHandler : ICommandHandler<SetMenuItemPermissions>
    {
        private readonly IMenuRepository _menuRepository;

        public SetMenuItemPermissionsHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public ICollection<IEvent> Handle(SetMenuItemPermissions cmd)
        {
            var menu = _menuRepository.GetById(cmd.SiteId, cmd.MenuId);

            if (menu == null)
                throw new Exception("Menu not found");

            menu.SetMenuItemPermissions(cmd);

            _menuRepository.Update(menu);

            return menu.Events;
        }
    }
}
