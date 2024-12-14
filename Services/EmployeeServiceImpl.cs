using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Services;

public class EmployeeServiceImpl : IEmployeeService
{
    EmployeeDbContext _dbContext;

    public EmployeeServiceImpl(EmployeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
    {
        _dbContext.Add(employee);
        await _dbContext.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> DeleteEmployee(int empId)
    {
        Employee? employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == empId);
        if(employee != null)
        {
            _dbContext.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
        return employee;
    }

    public async Task<ActionResult<IEnumerable<Employee>>?> GetAllEmployees()
    {
        if(_dbContext.Employees == null)
        {
            return null;
        }
        return await _dbContext.Employees.ToListAsync();
    }

    public async Task<ActionResult<Employee>?> GetEmployeeById(int empId)
    {
        Employee? employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == empId);
        if(employee == null)
        {
            return null;
        }
        return employee;
    }

    public async Task<Employee?> UpdateEmployee(int empId, Employee employee)
    {
        Employee? emp = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == empId);
        if(emp != null)
        {
            emp.Name = employee.Name;
            emp.Email = employee.Email;
            emp.Department = employee.Department;

            _dbContext.Update(emp);
            await _dbContext.SaveChangesAsync();
        }
        return emp;
    }
}