using LiteDB;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Common
{
    public static class LiteDbServiceExtension
    {
        public static void AddLiteDb(this IServiceCollection services, string databasePath)
        {
            services.AddTransient<LiteDbContext>();
            services.Configure<LiteDbOptions>(options => options.DatabasePath = databasePath);
        }
    }

    public class LiteDbContext:IDisposable
    {
        public readonly LiteDatabase Context;
        public LiteDbContext(IOptions<LiteDbOptions> configs)
        {
            try
            {
                var db = new LiteDatabase(configs.Value.DatabasePath);
                
                if (db != null)
                    Context = db;

            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }

    public class LiteDbOptions
    {
        public string DatabasePath { get; set; }
    }
}
