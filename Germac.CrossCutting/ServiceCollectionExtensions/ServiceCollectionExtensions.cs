using System;
using FluentValidation;
using Germac.CrossCutting.Behaviors;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Logging;
using Germac.Infrastructure.Repositories;
using Germac.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace Germac.CrossCutting.ServiceCollectionExtensions
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddSingleton<ILoggingService, LoggingService>();

            serviceCollection.AddTransient(x =>
              new MySqlConnection(configuration.GetConnectionString("Default")));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));

            serviceCollection.AddScoped<IPartRepository, PartRepository>();
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();


            //serviceCollection.AddValidatorsFromAssemblyContaining<CreateOrderValidator>();
        }
    }
}

