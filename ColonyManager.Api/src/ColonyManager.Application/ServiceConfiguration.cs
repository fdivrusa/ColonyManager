﻿using AutoMapper;
using ColonyManager.Application.Services;
using ColonyManager.Domain.Interfaces.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ColonyManager.Application
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddRegisteredServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssembly(typeof(ServiceConfiguration).Assembly);

            services.AddScoped<IConfigGenericGroupService, ConfigGenericGroupService>();
            services.AddScoped<IConfigGenericItemService, ConfigGenericItemService>();
            services.AddScoped<IConfigGenericItemExtentionService, ConfigGenericItemExtentionService>();
            services.AddScoped<IConfigGenericItemExtentionValueService, ConfigGenericItemExtentionValueService>();

            services.AddScoped<ISystemDataTypeService, SystemDataTypeService>();

            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<IPeopleInternetInformationService, PeopleInternetInformationService>();
            services.AddScoped<IPeoplePhoneInformationService, PeoplePhoneInformationService>();

            services.AddScoped<IColonyService, ColonyService>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
