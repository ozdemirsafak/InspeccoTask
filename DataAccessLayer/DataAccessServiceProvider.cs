using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DataAccessServiceProvider
    {
        public static void AddDataAccessServiceProvider(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            services.AddScoped<IUserDal, EfUserRepository>();
        }
    }
}
