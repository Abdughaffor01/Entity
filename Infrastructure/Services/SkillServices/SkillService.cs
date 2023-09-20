using Domain;
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

    public Task<Response<BaseSkillDto>> GetSkillByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<BaseSkillDto>>> GetSkillsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<BaseSkillDto>> UpdateSkillAsync(AddSkillDto model)
    {
        throw new NotImplementedException();
    }
}
