using Business.DTOs.Department.Request;
using Business.DTOs.Department.Response;
using Business.Services.Abstraction;
using Business.Validators.Department;
using Core.Entities;
using DataAccess.Repositories.Abstraction;

namespace Business.Services.Implementation;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<Response<DepartmentResponseDTO>> GetAllAsync()
    {
        var response = new Response<DepartmentResponseDTO>()
        {
            Data= new DepartmentResponseDTO()
            {
            Department = await _departmentRepository.GetAllAsync()
            }
        };
        return response;
    }

    public async Task<Response<DepartmentItemResponseDTO>> GetAsync(int id)
    {
        var response = new Response<DepartmentItemResponseDTO>();
        var department = await _departmentRepository.GetAsync(id);
        if (department == null)
        {
            response.Errors.Add("Department NotFound");
            response.Status = StatusCode.NotFound;
            return response;
        }
        response.Data = new DepartmentItemResponseDTO()
        {
            Department = department
        };
        return response;
    }

    public async Task<Response> CreateAsync(DepartmentCreateDTO model)
    {
        var response = new Response();

        DepartmentCreateDTOValidator validator = new DepartmentCreateDTOValidator();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)

                response.Errors.Add(error.ErrorMessage);
            response.Status = StatusCode.BadRequest;

            return response;
        }

        bool isExist = await _departmentRepository.AnyAsync(d => d.Title.ToLower().Trim() == model.Title.ToLower().Trim());
        if (isExist)
        {
            response.Errors.Add("This department is already exist");
            response.Status = StatusCode.BadRequest;
            return response;
        }

        var department = new Department
        {
            CreatedAt = DateTime.Now,
            Description = model.Description,
            Title = model.Title,
        };

        await _departmentRepository.CreateAsync(department);
        return response;
    }

    public async Task<Response> UpdateAsync(DepartmentUpdateDTO model)
    {
        var response = new Response();

        DepartmentUpdateDTOValidator validator = new DepartmentUpdateDTOValidator();
        var result = validator.Validate(model);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
                response.Errors.Add(error.ErrorMessage);
            response.Status = StatusCode.BadRequest;
            return response;
        }

        bool isExist = await _departmentRepository.AnyAsync(d => d.Title.ToLower().Trim() == model.Title.ToLower().Trim());
        if (isExist)
        {
            response.Errors.Add("This department is already exist");
            response.Status = StatusCode.BadRequest;
            return response;
        }

        var department = await _departmentRepository.GetAsync(model.Id);
        if (department == null)
        {
            response.Errors.Add("Department NotFound");
            response.Status = StatusCode.NotFound;
            return response;
        }

        department.Title = model.Title;
        department.Description = model.Description;
        department.ModifiedAt=DateTime.Now;
        await _departmentRepository.UpdateAsync(department);
        return response;
    }

    public async Task<Response> DeleteAsync(int id)
    {
        var response = new Response();

        var department = await _departmentRepository.GetAsync(id);
        if (department == null)
        {
            response.Errors.Add("Department Not Found");
            response.Status = StatusCode.NotFound;
            return response;
        }

        await _departmentRepository.DeleteAsync(department);
        return response;
    }
}

