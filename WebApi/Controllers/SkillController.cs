using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
public class SkillController:ControllerBase
{
    private readonly ISkillService _skillService;
    public SkillController(ISkillService skillService)=>_skillService = skillService;


    [HttpGet("GetSkillsAsync")]
    public async Task<Response<List<BaseSkillDto>>> GetSkillsAsync()=>await _skillService.GetSkillsAsync();

    [HttpGet("GetSkillByIdAsync")]
    public async Task<Response<BaseSkillDto>> GetSkillByIdAsync(int id)=>await _skillService.GetSkillByIdAsync(id);

    [HttpPost("AddSkillAsync")]
    public async Task<Response<BaseSkillDto>> AddSkillAsync(AddSkillDto model)=>await _skillService.AddSkillAsync(model);

    [HttpPut("UpdateSkillAsync")]
    public async Task<Response<BaseSkillDto>> UpdateSkillAsync(AddSkillDto model)=>await _skillService.UpdateSkillAsync(model);

    [HttpDelete("DeleteSkillAsync")]
    public async Task<Response<BaseSkillDto>> DeleteSkillAsync(int id) => await _skillService.DeleteSkillAsync(id);
}
