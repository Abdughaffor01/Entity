using Domain;
namespace Infrastructure;
public interface IEmployeeAddressServices
{
    Task<Response<string>> AddAddressToEmployee(AddEmployeeAddressDto model);
}
