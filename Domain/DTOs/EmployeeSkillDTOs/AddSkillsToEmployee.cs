namespace Domain;
public class AddSkillsToEmployee
{
    public int EmployeeId { get; set; }
    public List<SkillToEmployee> Skills { get; set; } =new List<SkillToEmployee>();
}


