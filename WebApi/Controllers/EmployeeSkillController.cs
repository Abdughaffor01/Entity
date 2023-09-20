using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
public class EmployeeSkillController : ControllerBase
{
    private readonly IEmployeeSkillService _employeeSkillService;
    public EmployeeSkillController(IEmployeeSkillService employeeSkillService) => _employeeSkillService = employeeSkillService;


    [HttpPost("AddSkillsToEmployeeAsync")]
    public async Task<Response<string>> AddSkillsToEmployeeAsync([FromBody] AddSkillsToEmployee model) => await _employeeSkillService.AddSkillsToEmployeeAsync(model);

    [HttpDelete("DeleteSkillsEmployeeById")]
    public async Task<Response<string>> DeleteSkillsEmployeeById(int id)=>await _employeeSkillService.DeleteSkillsEmployeeById(id);
}
