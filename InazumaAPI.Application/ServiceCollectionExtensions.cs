using InazumaAPI.Application.CommandBuss;
using InazumaAPI.Application.QueryBuss;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InazumaAPI.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();

            var handlers = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x =>
                    x.IsClass &&
                    !x.IsAbstract &&
                    x.GetInterfaces().Any(i =>
                        i.IsGenericType &&
                        (i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)
                            || i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>))));

            foreach (var handler in handlers)
            {
                var generic = handler
                    .GetInterfaces()
                    .Single(i => i.GetGenericTypeDefinition() == typeof(ICommandHandler<>) ||
                        i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>));

                services.AddScoped(generic, handler);
            }

            return services;
        }
        


    }
}
