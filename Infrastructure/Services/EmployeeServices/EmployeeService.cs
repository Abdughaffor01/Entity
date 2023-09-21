using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace Infrastructure;
public class EmployeeService : IEmployeeService
{
    private readonly DataContext _context;
    public EmployeeService(DataContext context)=>_context=context;
    public async Task<Response<BaseEmployeeDto>> AddEmployeeAsync(AddEmployeeDto model)
    {
        try
        {
            var newEmployee = new Employee()
            {
                Name = model.Name,
                CompanyId = model.CompanyId,
                EmployeeAddress=new ()
                {
                    Address=model.Address,
                    EmployeeId=model.Id
                }
            };
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return new Response<BaseEmployeeDto>(new BaseEmployeeDto()
            {
                Id = newEmployee.Id,
                Name = newEmployee.Name,
            });
        }
        catch (Exception ex)
        {
            return new Response<BaseEmployeeDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
    public async Task<Response<BaseEmployeeDto>> DeleteEmployeeAsync(int id)
    {
        try
        {
            var find= await _context.Employees.FindAsync(id);
            if (find == null) return new Response<BaseEmployeeDto>(HttpStatusCode.NotFound);
            _context.Employees.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<BaseEmployeeDto>(new BaseEmployeeDto() { 
                Id = find.Id,
                Name = find.Name,
            });
        }
        catch (Exception ex)
        {
            return new Response<BaseEmployeeDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
    public async Task<Response<GetEmployeeDto>> GetEmployeeById(int id)
    {
        try
        {
            var find = await _context.Employees.FindAsync(id);
            if (find == null) return new Response<GetEmployeeDto>(HttpStatusCode.NotFound);
            return new Response<GetEmployeeDto>(new GetEmployeeDto() { 
                Id =find.Id,
                Name =find.Name,
                CompanyName=find.Company.Name,
                EmpAddress=find.EmployeeAddress.Address
            });
        }
        catch (Exception ex)
        {
            return new Response<GetEmployeeDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<List<GetEmployeeDto>>> GetEmployeesAsync()
    {
        try
        {
            var employee = await _context.Employees.Select(x => new GetEmployeeDto()
            {
                Id = x.Id,
                Name = x.Name,
                EmpAddress = x.EmployeeAddress.Address,
                CompanyName = x.Company.Name,
                Skills = x.EmployeeSkills.Select(es=>new BaseSkillDto() { 
                    Id=es.SkillId,
                    SkillName=es.Skill.SkillName
                }).ToList(),
            }).ToListAsync();
            return new Response<List<GetEmployeeDto>>(employee);
        }
        catch (Exception ex)
        {
            return new Response<List<GetEmployeeDto>>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
    public async Task<Response<BaseEmployeeDto>> UpdateEmployeeAsync(AddEmployeeDto model)
    {
        try
        {
            var employee = await _context.Employees.FindAsync(model.Id);
            if (employee == null) return new Response<BaseEmployeeDto>(HttpStatusCode.NotFound);
            var addres=await _context.EmployeeAddresses.FirstOrDefaultAsync(a=>a.EmployeeId==employee.Id);
            if(addres!=null) addres.Address=model.Address;
            employee.Name = model.Name;
            employee.CompanyId = model.CompanyId;
            await _context.SaveChangesAsync();
            return new Response<BaseEmployeeDto>(new BaseEmployeeDto() { 
                Id=employee.Id,
                Name=employee.Name,  
            });
        }
        catch (Exception ex)
        {
            return new Response<BaseEmployeeDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}
