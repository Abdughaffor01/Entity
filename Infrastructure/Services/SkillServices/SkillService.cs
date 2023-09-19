using Domain;
using System.Net;

namespace Infrastructure;
public class SkillService : ISkillService
{
	private readonly DataContext _context;
    public SkillService(DataContext context)=>_context=context;
    public async Task<Response<string>> AddSkillAsync(AddSkillDto model)
    {
		try
		{
			await _context.Skills.AddAsync(new Skill()
			{
				SkillName = model.SkillName,
			});
			var res = await _context.SaveChangesAsync();
			return new Response<string>(HttpStatusCode.OK,"Successfuly added skill");
		}
		catch (Exception ex)
		{
			return new Response<string>(HttpStatusCode.BadRequest,ex.Message);
		}
    }
}
