using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShiftSystem.Infrastructure.Context;
using ShiftSystem.Infrastructure.Services.Modules_Services;
using ShiftSystem002.Application.Interfaces;

namespace ShiftSystem.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAzureFormRecognizerService, AzureFormRecognizerService>();

            services.AddTransient<IShiftSystemDbContext, ShiftSystemDbContext>();

            services.AddTransient<IPersonService, PersonService>();

            services.AddTransient<IPersonQueueService, PersonQueueService>();

            services.AddTransient<IQueueLineService, QueueLineService>();

            services.AddDbContext<ShiftSystemDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ShiftSystemDatabase")));

            return services;
        }
    }
}
