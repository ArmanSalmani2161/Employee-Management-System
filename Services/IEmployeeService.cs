using webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Services;

public interface IEmployeeService
{
    Task<ActionResult<Employee>> AddEmployee(Employee employee);
    
    Task<ActionResult<Employee>?> GetEmployeeById(int empId);
    
    Task<ActionResult<IEnumerable<Employee>>?> GetAllEmployees();
    
    Task<Employee?> DeleteEmployee(int empId);

    Task<Employee?> UpdateEmployee(int empId, Employee employee);
}