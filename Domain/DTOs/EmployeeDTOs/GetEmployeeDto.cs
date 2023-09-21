namespace Domain;
public class GetEmployeeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CompanyName { get; set; }
    public string EmpAddress { get; set; }
    public List<BaseSkillDto> Skills { get; set; }

}
