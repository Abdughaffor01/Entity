using Domain.DTOs.EmployeeAddressDTOs;

namespace Domain;
public class GetEmployeeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public BaseCompanyDto CompanyName { get; set; }
    public string EmpAddress { get; set; }
}
