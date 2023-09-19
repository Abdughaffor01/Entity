using Domain;
namespace Infrastructure;
public interface ICompanyService
{
    Task<Response<string>> AddCompanyAsync(AddCompanyDto model);
    Task<Response<List<GetCompanyDto>>> GetCompaniesAsync();
    Task<Response<GetCompanyDto>> GetCompanyByIdAsync(int companyId);
}
