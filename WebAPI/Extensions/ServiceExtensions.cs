using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureAPIUtils(this IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.UseGeneralRoutePrefix("bet-services/v{version:apiVersion}");
            });
            services.AddApiVersioning(options => options.ReportApiVersions = true);
            services.AddVersionedApiExplorer(options =>
            {
                // format "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}