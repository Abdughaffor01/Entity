using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class EmployeeController:ControllerBase
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService)=>_employeeService = employeeService;


    [HttpGet("GetEmployeesAsync")]
    public async Task<Response<List<GetEmployeeDto>>> GetEmployeesAsync()=>await _employeeService.GetEmployeesAsync();

    [HttpGet("GetEmployeeById")]    
    public async Task<Response<GetEmployeeDto>> GetEmployeeById(int id)=>await _employeeService.GetEmployeeById(id);

    [HttpPost("AddEmployeeAsync")]
    public async Task<Response<BaseEmployeeDto>> AddEmployeeAsync(AddEmployeeDto model)=>await _employeeService.AddEmployeeAsync(model);

    [HttpPut("UpdateEmployeeAsync")]
    public async Task<Response<BaseEmployeeDto>> UpdateEmployeeAsync(AddEmployeeDto model)=>await _employeeService.UpdateEmployeeAsync(model);  

    [HttpDelete("DeleteEmployeeAsync")]
    public async Task<Response<BaseEmployeeDto>> DeleteEmployeeAsync(int id)=>await  _employeeService.DeleteEmployeeAsync(id);

}
