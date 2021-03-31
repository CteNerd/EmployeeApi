using System;
using EmployeeBusinessLogic.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeBusinessLogic
{
    public static class Registrar
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IEmployeeService, Implementation.EmployeeService>();
        }
    }
}
