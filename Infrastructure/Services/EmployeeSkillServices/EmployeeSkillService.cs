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
                    var skil = await _context.Skills.FirstOrDefaultAsync(s => s.Id == skill.SkillId);
                    if (skil != null)
                    {
                        var employeeSkill = new EmployeeSkill()
                        {
                            EmployeeId = employee.Id,
                            SkillId = skill.SkillId
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




    //public async Task<Response<List<AddSkillsToEmployeeResponse>>> AddSkillsToEmployee(AddSkillsToEmployee model)
    //{
    //    try
    //    {
    //        var employee = await _dataContext.Employees.FirstOrDefaultAsync(x => x.Id == model.EmployeeId);
    //        if (employee == null) return new Response<List<AddSkillsToEmployeeResponse>>(HttpStatusCode.NotFound, "Employee not found !");

    //        var response = new List<AddSkillsToEmployeeResponse>();
    //        if (model.Skills.Count != 0)
    //        {
    //            foreach (var skillDto in model.Skills)
    //            {
    //                 var skill = await _dataContext.Skills.FirstOrDefaultAsync(x => x.Id == skillDto.SkillId);
    //                if (skill == null)
    //                {
    //                    response.Add(new AddSkillsToEmployeeResponse { EmployeeId = model.EmployeeId, SkillId = skillDto.SkillId, Response = "Skill not found !" });
    //                }

    //                var newSkillToEmployee = new EmployeeSkill
    //                {
    //                    EmployeeId = model.EmployeeId,
    //                    SkillId = skillDto.SkillId
    //                };

    //                await _dataContext.EmployeeSkills.AddAsync(newSkillToEmployee);
    //                var res = await _dataContext.SaveChangesAsync();

    //                if (res == 0)
    //                {
    //                    response.Add(new AddSkillsToEmployeeResponse { EmployeeId = model.EmployeeId, SkillId = skillDto.SkillId, Response = "Skill not added to employee !" });
    //                }
    //                response.Add(new AddSkillsToEmployeeResponse { EmployeeId = model.EmployeeId, SkillId = skillDto.SkillId, Response = "Skill successfully added to employee !" });
    //            }
    //        }
    //        else
    //        {
    //            return new Response<List<AddSkillsToEmployeeResponse>>(HttpStatusCode.NoContent, "Count of skills is 0");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        return new Response<List<AddSkillsToEmployeeResponse>>(HttpStatusCode.InternalServerError, ex.Message);
    //    }
    //}

    //public async task<response<getemployeedto>> getemployees()
    //{
    //    var employess = await _datacontext.employees.select(x => new getemployeedto
    //    {
    //        companyid = x.companyid,
    //        id = x.id,
    //        name = x.name,
    //        employeeaddress = x.employeeaddress,
    //        skills = _datacontext.employeeskills.where(s => s.employeeid == x.id).select(skill => new getemployeeskillsdto
    //        {
    //            id = skill.skillid,
    //            //skillname = skill.skill.skillname
    //            //skillname = _datacontext.skills.firstordefault(x=>x.id==skill.skillid).skillname
    //        }).tolist(),

    //    }).tolistasync();
    //}
}
