using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using MyApp.Common;

namespace MyApp
{
  

    public class Startup
    {
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Models.Movie>("movies");
            return builder.GetEdmModel();
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            services.AddLiteDb(@"movies.db");
            services.AddOData(opt => opt.AddModel("odata", GetEdmModel()));


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
