using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _service;
    public CompanyController(ICompanyService service)=>_service = service;


    [HttpGet("GetCompaniesAsync")]
    public async Task<Response<List<GetCompanyDto>>> GetCompaniesAsync()=>await _service.GetCompaniesAsync();

    [HttpGet("GetCompanyByIdAsync")]
    public async Task<Response<BaseCompanyDto>> GetCompanyByIdAsync(int companyId)=>await _service.GetCompanyByIdAsync(companyId);

    [HttpPost("AddCompanyAsync")]
    public async Task<Response<BaseCompanyDto>> AddCompanyAsync(AddCompanyDto model)=>await _service.AddCompanyAsync(model);

    [HttpPut("UpdateCompanyAsync")]
    public async Task<Response<BaseCompanyDto>> UpdateCompanyAsync(AddCompanyDto model)=>await _service.UpdateCompanyAsync(model);

    [HttpDelete("DeleteCompanyAsync")]
    public async Task<Response<string>> DeleteCompanyAsync(int id)=>await _service.DeleteCompanyAsync(id);
}
