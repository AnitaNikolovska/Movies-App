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

namespace Utilities
{
    //Microsoft.Extensions.DependencyInjection.Abstractions
    //Microsoft.EntityFrameworkCore.SqlServer
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterModule(this IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();

            services.AddTransient<IRepository<MovieDto>, MovieStaticDbRepository>();

            return services;
        }
    }
}
