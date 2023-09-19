namespace Domain;
public class GetEmployeeDto : BaseEmployeeDto
{
    public string CompanyName { get; set; }
    public EmployeeAddress EmployeeAddress { get; set; }
    public List<EmployeeSkillDto> Skills { get; set; } = new();
}
