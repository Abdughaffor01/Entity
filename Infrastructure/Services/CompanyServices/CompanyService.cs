using Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Net;
namespace Infrastructure;
public class CompanyService : ICompanyService
{
    private readonly DataContext _context;
    public CompanyService(DataContext context)=>_context = context;
    public async Task<Response<string>> AddCompanyAsync(AddCompanyDto model)
    {
		try
		{
			await _context.Companies.AddAsync(new Company()
			{
				Name = model.Name,
			});
			await _context.SaveChangesAsync();
			return new Response<string>(HttpStatusCode.OK,"Successfuly added company");
		}
		catch (Exception ex)
		{
			return new Response<string>(HttpStatusCode.BadRequest,ex.Message);
		}
    }
    public async Task<Response<GetCompanyDto>> GetCompanyByIdAsync(int companyId)
    {
		try
		{
			var company=await _context.Companies.FindAsync(companyId);
			if (company == null) return new Response<GetCompanyDto>(HttpStatusCode.OK,"not found");
			var employees = await _context.Employees.Where(x=>x.CompanyId==companyId).Select(x=>new GetEmployeesComanyDto { 
				Id = x.Id,
				Name=x.Name,
			}).ToListAsync();
            return new Response<GetCompanyDto>(new GetCompanyDto() { 
				Id = company.Id,
				Name = company.Name,
				Employees= employees
			});
		}
		catch (Exception ex)
		{
			return new Response<GetCompanyDto>(HttpStatusCode.BadRequest,ex.Message);
		}
    }

    public async Task<Response<List<GetCompanyDto>>> GetCompaniesAsync()
    {
        try
        {
			var list=new List<GetCompanyDto>();
			var company=await _context.Companies.ToListAsync();
			foreach (var c in company)
			{
				var employees = await _context.Employees.Where(x=>x.CompanyId==c.Id).Select(x => new GetEmployeesComanyDto()
				{
					Id = x.Id,
					Name = x.Name,
				}).ToListAsync();
				var com= new GetCompanyDto() { 
					Id= c.Id,
					Name= c.Name,
					Employees= employees
				};
				list.Add(com);
			}
			return new Response<List<GetCompanyDto>>(list);
        }
        catch (Exception ex)
        {
			return new Response<List<GetCompanyDto>>(HttpStatusCode.BadRequest,ex.Message);
        }
    }

}
