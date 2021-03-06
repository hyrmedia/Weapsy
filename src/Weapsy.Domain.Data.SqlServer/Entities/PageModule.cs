﻿using System;
using System.Collections.Generic;
using Weapsy.Domain.Pages;

namespace Weapsy.Domain.Data.SqlServer.Entities
{
    public class PageModule : IDbEntity
    {
        public Guid Id { get; set; }
        public Guid PageId { get; set; }
        public Guid ModuleId { get; set; }
        public string Title { get; set; }
        public string Zone { get; set; }
        public int SortOrder { get; set; }
        public PageModuleStatus Status { get; set; }
        public bool InheritPermissions { get; set; }

        public virtual ICollection<PageModuleLocalisation> PageModuleLocalisations { get; set; } = new List<PageModuleLocalisation>();
        public virtual ICollection<PageModulePermission> PageModulePermissions { get; set; } = new List<PageModulePermission>();
    }
}