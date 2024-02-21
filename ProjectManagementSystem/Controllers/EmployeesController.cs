using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS.Domain.Entities.HumanResource;
using ProjectManagementSystem.DtoObjects.Employee;

namespace ProjectManagementSystem.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeesController:ControllerBase
{
    private readonly DataContext _context;

    public EmployeesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseEmployeeDto>> Get()
    {
        try
        {
            
            var employees = await _context.Employees.AsNoTracking().ToListAsync();
            var respone = new List<ResponseEmployeeDto>();
            foreach (var employee in employees)
            {
                respone.Add(new ResponseEmployeeDto()
                {

                    Name = employee.Name,
                    LastName = employee.LastName,
                    Role = employee.Role,
                    BirthDate = employee.BirthDate,
                    RecruitmentDate = employee.RecruitmentDate,
                    Description = employee.Description

                });
            }

            return Ok(respone);

        }
        catch 
        {
            return StatusCode(500, "Internal Server Error");
        }


    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseEmployeeDto>> Get(int id)
    {
        
            try
            {
                var employeeForResponse = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

                if (employeeForResponse == null)
                    return NotFound();

                return Ok(employeeForResponse);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateEmployeeDto employee)
    {

        try
        {
            _context.Employees.Add(new Employee()
            {
                Name = employee.Name,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                RecruitmentDate = DateTime.Now.Date,
                Role = employee.Role,
                Description = employee.Description

            });

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", employee);
        }
        catch 
        {
            return StatusCode(500, "Internal Server Error");
        }
        
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateEmployeeDto employee)
    {
        try
        {
            var employeeForUpdate = _context.Employees.FirstOrDefault(x => x.Id == id);

            if (employeeForUpdate == null)
                return NotFound();

            employeeForUpdate.Name = employee.Name;
            employeeForUpdate.LastName = employee.LastName;
            employeeForUpdate.BirthDate = employee.BirthDate;
            employeeForUpdate.Role = employee.Role;
            employeeForUpdate.Description = employee.Description;


            await _context.SaveChangesAsync();

            return Ok("Updated");
        }
        catch
        {
            return StatusCode(500, "Internal Server Error");
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var employeeForRemove = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (employeeForRemove == null)
                return NotFound();

            _context.Employees.Remove(employeeForRemove);
            await _context.SaveChangesAsync();

            return Ok("Deleted");
        }
        catch
        {
            return StatusCode(500, "Internal Server Error");
        }
       
    }

}