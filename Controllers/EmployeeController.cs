using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>?> Get()
    {
        if(await _employeeService.GetAllEmployees() == null)
        {
            return NotFound("There are no records of employees");
        }
        return await _employeeService.GetAllEmployees();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>?> Get( [FromRoute] int id)
    {
        var employee = await _employeeService.GetEmployeeById(id);
        if(employee == null)
        {
            return NotFound("There are no records of this employee id");
        }
        return employee;
    }

    [HttpPost]
    public async Task<IActionResult> Post( [FromBody] Employee employee)
    {
        await _employeeService.AddEmployee(employee);
        return CreatedAtAction("Get", new { id = employee.Id } , employee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put( [FromRoute] int id, [FromBody] Employee employee)
    {
        if(id != employee.Id)
        {
            return BadRequest("Invalid Id. Please enter valid employee Id");
        } 
        Employee? emp = await _employeeService.UpdateEmployee(id, employee);
        if(emp == null)
        {
            return NotFound("There are no records of this employee id");
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete( [FromRoute] int id)
    {
        Employee? emp = await _employeeService.DeleteEmployee(id);
        if(emp == null)
        {
            return NotFound("There are no records of this employee id");
        }
        return NoContent();
    }
}