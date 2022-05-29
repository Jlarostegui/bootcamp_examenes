using ApoloApi.Aplication.Services;
using ApoloApi.Application.contracts.Services;
using ApoloApi.DataAccess;
using ApoloApi.DataAccess.Repositories;
using ApoloApiDataAccess.contracts;
using ApoloApiDataAccess.contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApoloApi.CrossCutting.Configuration
{
    public static class IoC
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IEmployeeServcice, EmployeeService>();
            services.AddTransient<IEmployeeServcice, EmployeeService>();
            return services;
        }
    }
}
