using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApp.Common;

namespace MyApp
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            services.AddLiteDb(@"movies.db");

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

            });
        }
    }
}
