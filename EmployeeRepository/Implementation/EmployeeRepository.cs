using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeRepository.Interface;
using Entities.DTO;
using Microsoft.VisualBasic.FileIO;
using Excel = Microsoft.Office.Interop.Excel;

namespace EmployeeRepository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<EmployeeDTO> _collection = new();

        public EmployeeRepository()
        {
            TextFieldParser reader = new TextFieldParser("../EmployeeRepository/Excel/data.csv") { TextFieldType = FieldType.Delimited };
            reader.SetDelimiters(",");
            while(!reader.EndOfData)
            {
                string[] employeeCSV = reader.ReadFields();
                Console.WriteLine(employeeCSV);

                int.TryParse(employeeCSV[8], out int employeeBalance);
                DateTime.TryParse(employeeCSV[9], out DateTime employeeBday);

                EmployeeDTO employeeDTO = new()
                {
                    FirstName = employeeCSV[0],
                    LastName = employeeCSV[1],
                    MemberId = employeeCSV[2],
                    Address = employeeCSV[3],
                    City = employeeCSV[4],
                    State = employeeCSV[5],
                    Zip = employeeCSV[6],
                    Email = employeeCSV[7],
                    Balance = employeeBalance,
                    Birthday = employeeBday,
                    FavoriteLocation = employeeCSV[10],
                    Phone = employeeCSV[11]
                };

                _collection.Add(employeeDTO);
            }

        }

        public EmployeeDTO GetEmployeeByEmail(string email)
        {
            EmployeeDTO employeeToFind = _collection.AsQueryable().FirstOrDefault(e => e.Email == email);
            return employeeToFind;
        }

        public EmployeeDTO GetEmployeeByPhone(string phone)
        {
            EmployeeDTO employeeToFind = _collection.AsQueryable().FirstOrDefault(e => e.Phone == phone);
            return employeeToFind;
        }

        public EmployeeDTO GetEmployeeByMemberId(string memberId)
        {
            EmployeeDTO employeeToFind = _collection.AsQueryable().FirstOrDefault(e => e.MemberId == memberId);
            return employeeToFind;
        }
    }
}
