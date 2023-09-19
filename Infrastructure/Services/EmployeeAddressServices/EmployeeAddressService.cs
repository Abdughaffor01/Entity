using Domain;
using System.Net;

namespace Infrastructure;
public class EmployeeAddressService : IEmployeeAddressServices
{
    private readonly DataContext _context;
    public EmployeeAddressService(DataContext context)=>_context = context;
    public async Task<Response<string>> AddAddressToEmployee(AddEmployeeAddressDto model)
    {
		try
		{
			await _context.EmployeeAddresses.AddAsync(new EmployeeAddress() { 
				EmployeeId=model.EmployeeId,
				Address=model.Address,
			});
			await _context.SaveChangesAsync();
			return new Response<string>(HttpStatusCode.OK,"Successfuly added addres");
		}
		catch (Exception ex)
		{
			return new Response<string>(HttpStatusCode.BadRequest, ex.Message);
		}
    }
}
