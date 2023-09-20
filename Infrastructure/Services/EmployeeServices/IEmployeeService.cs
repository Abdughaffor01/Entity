using Domain;
namespace Infrastructure;
public interface IEmployeeService
{
    Task<Response<List<GetEmployeeDto>>> GetEmployeesAsync();
    Task<Response<GetEmployeeDto>> GetEmployeeById(int id);
    Task<Response<BaseEmployeeDto>> AddEmployeeAsync(AddEmployeeDto model);
    Task<Response<BaseEmployeeDto>> DeleteEmployeeAsync(int id);
    Task<Response<BaseEmployeeDto>> UpdateEmployeeAsync(AddEmployeeDto model);
}
