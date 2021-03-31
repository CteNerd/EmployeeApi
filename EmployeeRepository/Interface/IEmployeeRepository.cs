using System;
using Entities.DTO;

namespace EmployeeRepository.Interface
{
    public interface IEmployeeRepository
    {
        EmployeeDTO GetEmployeeByMemberId(string memberId);
        EmployeeDTO GetEmployeeByPhone(string phone);
        EmployeeDTO GetEmployeeByEmail(string email);
    }
}
