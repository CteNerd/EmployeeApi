using System;
using Entities.API;
using Entities.DTO;

namespace Entities.Mapper
{
    public static class MapToResponse
    {
        public static EmployeeResponse MapEmployeeDtoToResponse(this EmployeeDTO employeeDTO)
        {
            return new EmployeeResponse
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                MemberId = employeeDTO.MemberId,
                Address = employeeDTO.Address,
                City = employeeDTO.City,
                State = employeeDTO.State,
                Zip = employeeDTO.Zip,
                Email = employeeDTO.Email,
                Balance = employeeDTO.Balance,
                Birthday = employeeDTO.Birthday,
                FavoriteLocation = employeeDTO.FavoriteLocation,
                Phone = employeeDTO.Phone,
            };
        }
    }
}
