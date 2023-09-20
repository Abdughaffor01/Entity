using Domain;
namespace Infrastructure;
public interface ICompanyService
{
    Task<Response<BaseCompanyDto>> AddCompanyAsync(AddCompanyDto model);
    Task<Response<BaseCompanyDto>> UpdateCompanyAsync(AddCompanyDto model);
    Task<Response<List<GetCompanyDto>>> GetCompaniesAsync();
    Task<Response<BaseCompanyDto>> GetCompanyByIdAsync(int companyId);
}
