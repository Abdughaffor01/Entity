using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure;
public class SkillService : ISkillService
{
	private readonly DataContext _context;
    public SkillService(DataContext context)=>_context=context;
    public async Task<Response<BaseSkillDto>> AddSkillAsync(AddSkillDto model)
    {
		try
		{
            var skill=new Skill() {
                SkillName = model.SkillName,
            };
			await _context.Skills.AddAsync(skill);
			var res = await _context.SaveChangesAsync();
            return new Response<BaseSkillDto>(new BaseSkillDto()
            {
                Id=skill.Id,
                SkillName=model.SkillName,
            });
		}
		catch (Exception ex)
		{
            return new Response<BaseSkillDto>(HttpStatusCode.InternalServerError,ex.Message);
		}
    }

    public async Task<Response<BaseSkillDto>> DeleteSkillAsync(int id)
    {
        try
        {
            var skill=await _context.Skills.FindAsync(id);
            if (skill == null) return new Response<BaseSkillDto>(HttpStatusCode.NotFound);
            _context.Skills.Remove(skill);  
            await _context.SaveChangesAsync();
            return new Response<BaseSkillDto>(new BaseSkillDto()
            {
                Id = skill.Id,
                SkillName=skill.SkillName
            });
        }
        catch (Exception ex)
        {
            return new Response<BaseSkillDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<BaseSkillDto>> GetSkillByIdAsync(int id)
    {
        try
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return new Response<BaseSkillDto>(HttpStatusCode.NotFound);
            return new Response<BaseSkillDto>(new BaseSkillDto() {
                Id = skill.Id,
                SkillName=skill.SkillName  
            });
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<Response<List<BaseSkillDto>>> GetSkillsAsync()
    {
        try
        {
            var skills=await _context.Skills.Select(x=>new BaseSkillDto() { 
                Id=x.Id,
                SkillName=x.SkillName,
            }).ToListAsync();
            if (skills == null) return new Response<List<BaseSkillDto>>(HttpStatusCode.NotFound);
            return new Response<List<BaseSkillDto>>(skills);
        }
        catch (Exception ex)
        {
            return new Response<List<BaseSkillDto>>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<BaseSkillDto>> UpdateSkillAsync(AddSkillDto model)
    {
        try
        {
            var skill=await _context.Skills.FindAsync(model.Id);
            if (skill == null) return new Response<BaseSkillDto>(HttpStatusCode.NotFound);
            skill.SkillName = model.SkillName;
            await _context.SaveChangesAsync();
            return new Response<BaseSkillDto>(new BaseSkillDto() { 
                Id=skill.Id, SkillName=skill.SkillName,
            });
        }
        catch (Exception ex)
        {
            return new Response<BaseSkillDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
