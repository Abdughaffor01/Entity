using Domain;
namespace Infrastructure;
public interface ISkillService
{
    Task<Response<string>> AddSkillAsync(AddSkillDto model);
}
