﻿using System;
using Weapsy.Domain.Themes;

namespace Weapsy.Domain.Data.SqlServer.Entities
{
    public class Theme : IDbEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Folder { get; set; }
        public int SortOrder { get; set; }
        public ThemeStatus Status { get; set; }
    }
}
