using System;
using EmployeeRepository.Implementation;
using EmployeeRepository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeRepository
{
    public static class Registrar
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IEmployeeRepository, Implementation.EmployeeRepository>();
        }
    }
}
