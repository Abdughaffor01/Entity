using Domain;
namespace Infrastructure;
public interface ISkillService
{

    Task<Response<List<BaseSkillDto>>> GetSkillsAsync();
    Task<Response<BaseSkillDto>> GetSkillByIdAsync(int id);
    Task<Response<BaseSkillDto>> AddSkillAsync(AddSkillDto model);
    Task<Response<BaseSkillDto>> UpdateSkillAsync(AddSkillDto model);
    Task<Response<BaseSkillDto>> DeleteSkillAsync(int id);

}
