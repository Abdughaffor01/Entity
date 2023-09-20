using Domain;
using Domain.DTOs.EmployeeAddressDTOs;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace Infrastructure;
public class EmployeeAddressService : IEmployeeAddressServices
{
    private readonly DataContext _context;
    public EmployeeAddressService(DataContext context)=>_context = context;
    public async Task<Response<GetEmployeeAddressDto>> AddAddressToEmployee(AddEmployeeAddressDto model)
    {
		try
		{
            var address = new EmployeeAddress()
            {
                EmployeeId = model.EmployeeId,
                Address = model.Address
            };
            await _context.EmployeeAddresses.AddAsync(address);
			await _context.SaveChangesAsync();
			return new Response<GetEmployeeAddressDto>(new GetEmployeeAddressDto() { 
                EmployeeId=model.EmployeeId,
                Address = model.Address
            });
		}
		catch (Exception ex)
		{
			return new Response<GetEmployeeAddressDto>(HttpStatusCode.BadRequest, ex.Message);
		}
    }

    public async Task<Response<BaseEmployeeAddressDto>> DeleteAddressToEmployee(int id)
    {
        try
        {
            var address = await _context.EmployeeAddresses.FindAsync(id);
            if (address == null) return new Response<BaseEmployeeAddressDto>(HttpStatusCode.NotFound);
             _context.EmployeeAddresses.Remove(address);
            await _context.SaveChangesAsync();
            return new Response<BaseEmployeeAddressDto>(new BaseEmployeeAddressDto() { 
                EmployeeId=address.EmployeeId,
                Address = address.Address
            });
        }
        catch (Exception ex)
        {
            return new Response<BaseEmployeeAddressDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<GetEmployeeAddressDto>> GetAddressByIdToEmployee(int id)
    {
        try
        {
            var address=await _context.EmployeeAddresses.FindAsync(id);
            if (address == null) return new Response<GetEmployeeAddressDto>(HttpStatusCode.NotFound);
            return new Response<GetEmployeeAddressDto>(new GetEmployeeAddressDto()
            {
                EmployeeId=address.EmployeeId,
                Address=address.Address
            });

        }
        catch (Exception ex)
        {
            return new Response<GetEmployeeAddressDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetEmployeeAddressDto>>> GetAddressesToEmployee()
    {
        try
        {
            var addresses = await _context.EmployeeAddresses.Select(x => new GetEmployeeAddressDto()
            {
                EmployeeId = x.EmployeeId,
                Address = x.Address
            }).ToListAsync();
            if (addresses == null) return new Response<List<GetEmployeeAddressDto>>(HttpStatusCode.NotFound);
            return new Response<List<GetEmployeeAddressDto>>(addresses);
        }
        catch (Exception ex)
        {
            return new Response<List<GetEmployeeAddressDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<BaseEmployeeAddressDto>> UpdateAddressToEmployee(AddEmployeeAddressDto model)
    {
        try
        {
            var address = await _context.EmployeeAddresses.FindAsync(model.EmployeeId);
            if (address == null) return new Response<BaseEmployeeAddressDto>(HttpStatusCode.NotFound);
            address.EmployeeId=model.EmployeeId; 
            address.Address=model.Address;
            await _context.SaveChangesAsync();
            return new Response<BaseEmployeeAddressDto>(new BaseEmployeeAddressDto() { 
                EmployeeId=model.EmployeeId,
                Address=model.Address
            });
        }
        catch (Exception ex)
        {
            return new Response<BaseEmployeeAddressDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}
