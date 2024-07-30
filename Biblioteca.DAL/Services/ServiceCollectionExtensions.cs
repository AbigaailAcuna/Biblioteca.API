using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Biblioteca.DAL.Interfaces;

namespace Biblioteca.DAL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryConnector(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseRepository, DatabaseRepository>();
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<IEditorialRepository, EditorialRepository>();
            services.AddTransient<ILibroRepository, LibroRepository>();
            return services;
        }

          
    }
}
