namespace Domain;
public class GetCompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<GetEmployeesComanyDto> Employees { get; set; }=new List<GetEmployeesComanyDto>();
}
