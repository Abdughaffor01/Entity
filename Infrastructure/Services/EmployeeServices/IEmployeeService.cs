using Domain;
namespace Infrastructure;
public interface IEmployeeService
{
    Task<Response<string>> AddEmployeeAsync(AddEmployeeDto model);
    Task<Response<string>> DeleteEmployeeAsync(int id);
    Task<Response<string>> UpdateEmployeeAsync(UpdateEmployeeDto model);
    Task<Response<List<GetEmployeeDto>>> GetEmployeesAsync();
    Task<Response<GetEmployeeDto>> GetEmployeeById(int id);
}
