using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class BusinessServiceProvider
    {
        public static void AddBusinessServiceProvider(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>();
        }
    }
}
