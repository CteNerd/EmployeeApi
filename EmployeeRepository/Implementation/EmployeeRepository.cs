using System;
using EmployeeRepository.Interface;
using Entities.API;
using Entities.DTO;

namespace EmployeeRepository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository()
        {
        }

        public EmployeeDTO GetEmployeeByEmail(string email)
        {
            return new EmployeeDTO();
        }

        public EmployeeDTO GetEmployeeByPhone(string phone)
        {
            return new EmployeeDTO();
        }

        public EmployeeDTO GetEmployeeByMemberId(string memberId)
        {
            return new EmployeeDTO();
        }
    }
}
