using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using ApplicationCore.Services.Interface;
using Infrastructure;
using Infrastructure.Repositories;
using Infrastructure.Repositories.ApplicationRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Services.GobalServices
{
    public static class ServiceConfiguration
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
