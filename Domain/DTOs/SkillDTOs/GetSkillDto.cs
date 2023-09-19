namespace Domain;
public class GetSkillDto:BaseSkillDto
{
    public int Id { get; set; }
    public List<EmployeeSkill> EmployeeSkills { get; set; }=new List<EmployeeSkill>();
}
