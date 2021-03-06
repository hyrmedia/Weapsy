﻿using System.Reflection;
using Autofac;
using FluentValidation;
using Weapsy.Apps.Text.Data.SqlServer;
using Weapsy.Apps.Text.Domain;
using Weapsy.Apps.Text.Domain.Data.SqlServer;
using Weapsy.Apps.Text.Domain.Handlers;
using Weapsy.Apps.Text.Domain.Rules;
using Weapsy.Apps.Text.Domain.Validators;
using Weapsy.Apps.Text.Reporting;
using Weapsy.Infrastructure.Domain;

namespace Weapsy.Apps.Text.DependencyConfigurator
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TextModuleDbContext>().As<TextModuleDbContext>();

            builder.RegisterAssemblyTypes(typeof(CreateTextModuleHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(ICommandHandler<>));
            builder.RegisterAssemblyTypes(typeof(CreateTextModuleValidator).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IValidator<>));
            builder.RegisterAssemblyTypes(typeof(TextModuleEventsHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IEventHandler<>));

            builder.RegisterType<TextModuleRules>().As<ITextModuleRules>();
            builder.RegisterType<TextModuleRepository>().As<ITextModuleRepository>();
            builder.RegisterType<TextModuleFacade>().As<ITextModuleFacade>();
        }
    }
}
