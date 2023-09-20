using Domain;
using Domain.DTOs.EmployeeAddressDTOs;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class EmployeeAddressController : ControllerBase
{
    private readonly IEmployeeAddressServices _services;
    public EmployeeAddressController(IEmployeeAddressServices services) => _services = services;


    [HttpGet("GetAddressesToEmployee")]
    public async Task<Response<List<GetEmployeeAddressDto>>> GetAddressesToEmployee()=>await _services.GetAddressesToEmployee();

    [HttpGet("GetAddressByIdToEmployee")]
    public async Task<Response<GetEmployeeAddressDto>> GetAddressByIdToEmployee(int id)=>await _services.GetAddressByIdToEmployee(id); 

    [HttpPost("AddAddressToEmployee")]
    public async Task<Response<GetEmployeeAddressDto>> AddAddressToEmployee(AddEmployeeAddressDto model) => await _services.AddAddressToEmployee(model);

    [HttpPut("UpdateAddressToEmployee")]
    public async Task<Response<BaseEmployeeAddressDto>> UpdateAddressToEmployee(AddEmployeeAddressDto model)=>await _services.UpdateAddressToEmployee(model);

    [HttpDelete("DeleteAddressToEmployee")]
    public async Task<Response<BaseEmployeeAddressDto>> DeleteAddressToEmployee(int id)=>await _services.DeleteAddressToEmployee(id);
}
