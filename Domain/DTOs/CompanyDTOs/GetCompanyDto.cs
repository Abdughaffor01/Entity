namespace Domain;
public class GetCompanyDto : BaseCompanyDto
{
    public List<BaseEmployeeDto> Employees { get; set; } = new List<BaseEmployeeDto>();
}
