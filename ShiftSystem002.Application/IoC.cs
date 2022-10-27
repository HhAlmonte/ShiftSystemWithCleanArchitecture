using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ShiftSystem002.Application.Person.Handler;
using ShiftSystem002.Application.PersonQueue.Handler;
using ShiftSystem002.Application.QueueLine.Handler;
using System.Reflection;

namespace ShiftSystem002.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IPersonHandler, PersonHandler>();

            services.AddTransient<IQueueLineHandler, QueueLineHandler>();

            services.AddTransient<IPersonQueueHandler, PersonQueueHandler>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
