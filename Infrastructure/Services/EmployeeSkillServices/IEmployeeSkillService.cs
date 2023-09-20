using Domain;

namespace Infrastructure;
public interface IEmployeeSkillService
{
    Task<Response<string>> AddSkillsToEmployeeAsync(AddSkillsToEmployee model);
    Task<Response<string>> DeleteSkillsEmployeeById(int id);
}