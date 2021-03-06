﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Weapsy.Domain.Themes;
using Theme = Weapsy.Domain.Themes.Theme;
using ThemeDbEntity = Weapsy.Domain.Data.SqlServer.Entities.Theme;

namespace Weapsy.Domain.Data.SqlServer.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly IWeapsyDbContextFactory _dbContextFactory;
        private readonly IMapper _mapper;

        public ThemeRepository(IWeapsyDbContextFactory dbContextFactory, IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }

        public Theme GetById(Guid id)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbEntity = context.Set<ThemeDbEntity>()
                    .FirstOrDefault(x => x.Id == id && x.Status != ThemeStatus.Deleted);
                return dbEntity != null ? _mapper.Map<Theme>(dbEntity) : null;
            }
        }

        public Theme GetByName(string name)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbEntity = context.Set<ThemeDbEntity>()
                    .FirstOrDefault(x => x.Name == name && x.Status != ThemeStatus.Deleted);
                return dbEntity != null ? _mapper.Map<Theme>(dbEntity) : null;
            }
        }

        public Theme GetByFolder(string folder)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbEntity = context.Set<ThemeDbEntity>()
                    .FirstOrDefault(x => x.Folder == folder && x.Status != ThemeStatus.Deleted);
                return dbEntity != null ? _mapper.Map<Theme>(dbEntity) : null;
            }
        }

        public ICollection<Theme> GetAll()
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbEntities = context.Set<ThemeDbEntity>()
                    .Where(x => x.Status != ThemeStatus.Deleted)
                    .OrderBy(x => x.SortOrder)
                    .ToList();
                return _mapper.Map<ICollection<Theme>>(dbEntities);
            }
        }

        public int GetThemesCount()
        {
            using (var context = _dbContextFactory.Create())
            {
                return context.Set<ThemeDbEntity>().Count(x => x.Status != ThemeStatus.Deleted);
            }
        }

        public void Create(Theme theme)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbEntity = _mapper.Map<ThemeDbEntity>(theme);
                context.Add(dbEntity);
                context.SaveChanges();
            }
        }

        public void Update(Theme theme)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbEntity = _mapper.Map<ThemeDbEntity>(theme);
                context.Update(dbEntity);
                context.SaveChanges();
            }
        }

        public void Update(IEnumerable<Theme> themes)
        {
            using (var context = _dbContextFactory.Create())
            {
                foreach (var theme in themes)
                {
                    var dbEntity = _mapper.Map<ThemeDbEntity>(theme);
                    context.Update(dbEntity);
                }
                context.SaveChanges();
            }
        }
    }
}
