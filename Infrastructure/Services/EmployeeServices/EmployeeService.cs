using Domain;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Net;
namespace Infrastructure;
public class EmployeeService : IEmployeeService
{
    private readonly DataContext _dataContext;
    public EmployeeService(DataContext dataContext)=>_dataContext=dataContext;
    public async Task<Response<string>> AddEmployeeAsync(AddEmployeeDto model)
    {
        try
        {
            var newEmployee = new Employee()
            {
                Name = model.Name,
                CompanyId = model.CompanyId,
            };

            await _dataContext.Employees.AddAsync(newEmployee);
            await _dataContext.SaveChangesAsync();

            return new Response<string>(HttpStatusCode.OK,"Successfuly added employee");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.BadRequest,ex.Message);
        }
    }

    public async Task<Response<string>> DeleteEmployeeAsync(int id)
    {
        try
        {
            var find=await _dataContext.Employees.FindAsync(id);
            if (find == null) return new Response<string>(HttpStatusCode.OK, "not found");
            _dataContext.Employees.Remove(find);
            await _dataContext.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Successfuly deleted employee");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.BadRequest,ex.Message);
        }
    }

    public async Task<Response<GetEmployeeDto>> GetEmployeeById(int id)
    {
        try
        {
            var find = await _dataContext.Employees.FirstOrDefaultAsync(e=>e.Id==id);
            if (find == null) return new Response<GetEmployeeDto>(HttpStatusCode.OK,"not found");
            var namecompany = await _dataContext.Companies.FirstOrDefaultAsync(s => s.Id == find.Id);
            return new Response<GetEmployeeDto>(new GetEmployeeDto() { 
                Id =find.Id,
                Name =find.Name,
                CompanyName = namecompany.Name,
            });
        }
        catch (Exception ex)
        {
            return new Response<GetEmployeeDto>(HttpStatusCode.BadRequest, ex.Message);
        }
    }

    public Task<Response<List<GetEmployeeDto>>> GetEmployeesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> UpdateEmployeeAsync(UpdateEmployeeDto model)
    {
        throw new NotImplementedException();
    }
}
