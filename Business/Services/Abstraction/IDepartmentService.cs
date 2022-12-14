using Business.DTOs.Department.Request;
using Business.DTOs.Department.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstraction
{
    public interface IDepartmentService
    {
        Task<Response<DepartmentResponseDTO>> GetAllAsync();
        Task<Response<DepartmentItemResponseDTO>> GetAsync(int id);
        Task<Response> CreateAsync(DepartmentCreateDTO model);
        Task<Response> UpdateAsync(DepartmentUpdateDTO model);
        Task<Response> DeleteAsync(int id);
    }
}
