using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
public class SkillController:ControllerBase
{
    private readonly ISkillService _skillService;
    public SkillController(ISkillService skillService)=>_skillService = skillService;


    [HttpPost("AddSkillAsync")]
    public async Task<Response<BaseSkillDto>> AddSkillAsync(AddSkillDto model)=>await _skillService.AddSkillAsync(model);

    [HttpDelete("DeleteSkillAsync")]
    public async Task<Response<BaseSkillDto>> DeleteSkillAsync(int id)=>await _skillService.DeleteSkillAsync(id);
}
