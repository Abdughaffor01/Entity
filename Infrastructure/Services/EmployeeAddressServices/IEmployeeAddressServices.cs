using Domain;
using Domain.DTOs.EmployeeAddressDTOs;

namespace Infrastructure;
public interface IEmployeeAddressServices
{
    Task<Response<GetEmployeeAddressDto>> AddAddressToEmployee(AddEmployeeAddressDto model);
    Task<Response<BaseEmployeeAddressDto>> UpdateAddressToEmployee(AddEmployeeAddressDto model);
    Task<Response<BaseEmployeeAddressDto>> DeleteAddressToEmployee(int id);
    Task<Response<GetEmployeeAddressDto>> GetAddressByIdToEmployee(int id);
    Task<Response<List<GetEmployeeAddressDto>>> GetAddressesToEmployee();
}
