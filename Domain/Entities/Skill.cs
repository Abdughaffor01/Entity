using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Skill
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string SkillName { get; set; }
    public List<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();
}
