using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("controller")]
public class EmployeeAddressController:ControllerBase
{
    private readonly IEmployeeAddressServices _services;
    public EmployeeAddressController(IEmployeeAddressServices services)=>_services = services;
    [HttpPost("AddAddressToEmployee")]
    public async Task<Response<string>> AddAddressToEmployee(AddEmployeeAddressDto model)=>await _services.AddAddressToEmployee(model);
}
