
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;

namespace Recipes.Api
{
    public static class IWebHostExtensions
    {
        public static IWebHost Migrate<T>(this IWebHost webHost) where T: DbContext
        {
            using (IServiceScope scope = webHost.Services.CreateScope())
            {
                 IServiceProvider services = scope.ServiceProvider;
                 T context = services.GetRequiredService<T>();
                 context.Database.Migrate();
            }

            return webHost;
        }
    }
}