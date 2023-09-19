using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Employee
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public EmployeeAddress EmployeeAddress { get; set; }
    public List<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();
}