using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.DAL;
using MoviesApp.DAL.Repositories;
using MoviesApp.DataModels;
using MoviesApp.Services.Interfaces;
using MoviesApp.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Utilities
{
    //Microsoft.Extensions.DependencyInjection.Abstractions
    //Microsoft.EntityFrameworkCore.SqlServer
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterModule(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MoviesAppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<IMovieService, MovieService>();

            //services.AddTransient<IRepository<MovieDto>, MovieStaticDbRepository>();
            services.AddTransient<IRepository<MovieDto>, MovieEntityRepository>();

            return services;
        }
    }
}
