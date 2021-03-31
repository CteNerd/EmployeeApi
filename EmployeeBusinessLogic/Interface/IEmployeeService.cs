using System;
using Entities.API;

namespace EmployeeBusinessLogic.Interface
{
    public interface IEmployeeService
    {
        EmployeeResponse GetEmployeeByEmail(string email);
        EmployeeResponse GetEmployeeByPhone(string phone);
        EmployeeResponse GetEmployeeByMemberId(string memberId);
    }
}
