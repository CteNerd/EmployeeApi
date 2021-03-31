using System;
using EmployeeBusinessLogic.Interface;
using EmployeeRepository.Interface;
using Entities.API;
using Entities.DTO;

namespace EmployeeBusinessLogic.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeResponse GetEmployeeByEmail(string email)
        {
            EmployeeDTO employee = _employeeRepository.GetEmployeeByEmail(email);
            return new EmployeeResponse(employee);
        }

        public EmployeeResponse GetEmployeeByPhone(string phone)
        {
            EmployeeDTO employee = _employeeRepository.GetEmployeeByPhone(phone);
            return new EmployeeResponse(employee);
        }

        public EmployeeResponse GetEmployeeByMemberId(string memberId)
        {
            EmployeeDTO employee = _employeeRepository.GetEmployeeByMemberId(memberId);
            return new EmployeeResponse(employee);
        }
    }
}
