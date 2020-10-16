using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yoyo.Web.Data;
using Yoyo.Web.Interfaces;
using Yoyo.Web.Repository;

namespace Yoyo.Web
{
    /// <summary>
    /// Service Registry registers all the services that we created in the project.
    /// </summary>
    public class ServiceRegistry
    {
        public static void AddScopedServices(IServiceCollection services)
        {
            // Scoped service because we want a single instance of the service throughout the application.
            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<IAtheleteRepository, AtheleteRepository>();
            services.AddScoped<IFitnessRatingRepository, FitnessRatingRepository>();
        }
    }
}
