using InazumaAPI.Reads.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Reads
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            foreach (var queryInterface in GetQueriesInterfaces())
            {
                var implementation = GetQueryImplementation(queryInterface);
                services.AddScoped(queryInterface, implementation);
            }

            return services;
        }

        private static IEnumerable<Type> GetQueriesInterfaces()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(x =>
                    x.IsInterface &&
                    x.GetInterfaces().Any(i => i == typeof(IQuery)));
        }

        private static Type GetQueryImplementation(Type interfaceType)
        {
            var implementations = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x =>
                    x.IsClass &&
                    !x.IsAbstract &&
                    x.GetInterfaces().Any(i => i == interfaceType));

            return implementations.Single();
        }
    }
}
