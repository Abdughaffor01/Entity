namespace Domain;
public class GetEmployeeDto:BaseEmployeeDto
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public EmployeeAddress EmployeeAddress { get; set; }
    public List<EmployeeSkillDto> Skills { get; set; } = new List<EmployeeSkillDto>();
}
