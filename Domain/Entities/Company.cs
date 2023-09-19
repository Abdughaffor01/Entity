using System.ComponentModel.DataAnnotations;
namespace Domain;
public class Company
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();
}
