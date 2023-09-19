namespace Domain;
public class AddEmployeeDto : BaseEmployeeDto
{
    public int CompanyId { get; set; }
    public AddEmployeeAddressDto? EmployeeAddressDto { get; set; }
}
