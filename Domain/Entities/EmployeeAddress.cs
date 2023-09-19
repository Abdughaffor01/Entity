using System.ComponentModel.DataAnnotations;
namespace Domain;
public class EmployeeAddress
{
    [MaxLength(30)]
    public string Address { get; set; }
    [Key]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}