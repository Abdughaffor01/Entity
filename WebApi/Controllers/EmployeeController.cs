using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class EmployeeController:ControllerBase
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService)=>_employeeService = employeeService;


    [HttpPost("AddEmployeeAsync")]
    public async Task<Response<string>> AddEmployeeAsync(AddEmployeeDto model)=>await _employeeService.AddEmployeeAsync(model);

}
