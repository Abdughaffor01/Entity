using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace Infrastructure;
public class CompanyService : ICompanyService
{
	private readonly DataContext _context;
	public CompanyService(DataContext context) => _context = context;
	public async Task<Response<BaseCompanyDto>> AddCompanyAsync(AddCompanyDto model)
	{
		try
		{
			var company = new Company(){Name = model.Name};
			await _context.Companies.AddAsync(company);
			await _context.SaveChangesAsync();
			return new Response<BaseCompanyDto>(new BaseCompanyDto()
			{
				Id = company.Id,
				Name = company.Name
			});
		}
		catch (Exception ex)
		{
			return new Response<BaseCompanyDto>(HttpStatusCode.BadRequest, ex.Message);
		}
	}
	public async Task<Response<BaseCompanyDto>> UpdateCompanyAsync(AddCompanyDto model)
	{
		try
		{
			var company = await _context.Companies.FindAsync(model.Id);
			if (company == null) return new Response<BaseCompanyDto>(HttpStatusCode.BadRequest,"not found");
			company.Name = model.Name;
			await _context.SaveChangesAsync();
			return new Response<BaseCompanyDto>(new BaseCompanyDto()
			{
				Id = company.Id,
				Name = company.Name
			});
		}
		catch (Exception ex)
		{
			return new Response<BaseCompanyDto>(HttpStatusCode.BadRequest, ex.Message);
		}
	}
	public async Task<Response<BaseCompanyDto>> GetCompanyByIdAsync(int companyId)
	{
		try
		{
			var company = await _context.Companies.FindAsync(companyId);
			if (company == null) return new Response<BaseCompanyDto>(HttpStatusCode.BadRequest, "not found");
			return new Response<BaseCompanyDto>(
				new GetCompanyDto()
				{
					Id = company.Id,
					Name = company.Name
				}
			);
		}
		catch (Exception ex)
		{
			return new Response<BaseCompanyDto>(HttpStatusCode.BadRequest, ex.Message);
		}
	}
	public async Task<Response<List<GetCompanyDto>>> GetCompaniesAsync()
	{
		try
		{
			var companies = await _context.Companies.Select(c => new GetCompanyDto()
			{
				Id = c.Id,
				Name = c.Name,
				Employees = c.Employees.Select(e => new BaseEmployeeDto()
				{
					Id = e.Id,
					Name = e.Name
				}).ToList()
			}).ToListAsync();
			return new Response<List<GetCompanyDto>>(companies);
		}
		catch (Exception ex)
		{
			return new Response<List<GetCompanyDto>>(HttpStatusCode.BadRequest, ex.Message);
		}
	}

}
