using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _service;
    public CompanyController(ICompanyService service)=>_service = service;


    [HttpPost("AddCompanyAsync")]
    public async Task<Response<string>> AddCompanyAsync(AddCompanyDto model)=>await _service.AddCompanyAsync(model);

    [HttpGet("GetCompaniesAsync")]
    public async Task<Response<List<GetCompanyDto>>> GetCompaniesAsync()=>await _service.GetCompaniesAsync();

    [HttpGet("GetCompanyByIdAsync")]
    public async Task<Response<GetCompanyDto>> GetCompanyByIdAsync(int companyId)=>await _service.GetCompanyByIdAsync(companyId);
}
