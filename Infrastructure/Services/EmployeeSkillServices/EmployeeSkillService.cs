using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure;
public class EmployeeSkillService : IEmployeeSkillService
{
    private readonly DataContext _context;
    public EmployeeSkillService(DataContext context) => _context = context;

    public async Task<Response<string>> AddSkillsToEmployeeAsync(AddSkillsToEmployee model)
    {
        try
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x=>x.Id==model.EmployeeId);

            if (employee == null) return new Response<string>(HttpStatusCode.NotFound,"not found employee");
            if (model.Skills.Count != 0) {
                foreach (var skill in model.Skills)
                {
                    var skil = await _context.Skills.FirstOrDefaultAsync(s => s.Id == skill);
                    if (skil != null)
                    {
                        var employeeSkill = new EmployeeSkill()
                        {
                            EmployeeId = employee.Id,
                            SkillId = skill
                        };
                        await _context.EmployeeSkills.AddAsync(employeeSkill);
                        var res = await _context.SaveChangesAsync();
                        return new Response<string>(HttpStatusCode.OK, "Successfuly added skill to employee");
                    }
                }
            }
            return new Response<string>(HttpStatusCode.NoContent,"not skill");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.BadRequest, ex.Message);
        }
    }

    public async Task<Response<string>> DeleteSkillsEmployeeById(int id)
    {
        try
        {
            var employeSkill = await _context.EmployeeSkills.ToListAsync();
            if (employeSkill == null) return new Response<string>(HttpStatusCode.NotFound);
            _context.EmployeeSkills.RemoveRange(employeSkill);
            await _context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"deleted skills on employee");
        }
        catch (Exception ex)
        {
            return new Response<string> ( HttpStatusCode.InternalServerError, ex.Message);
        }
    }

}
