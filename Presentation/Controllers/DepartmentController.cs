using Business.DTOs.Department.Request;
using Business.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        #region Documentation
        /// <summary>
        /// Get all Departments
        /// </summary>
        /// <returns></returns>
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _departmentService.GetAllAsync());
        }

        #region Documentation
        /// <summary>
        /// Get department by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _departmentService.GetAsync(id));
        }

        #region Documentation
        /// <summary>
        /// Create department
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        #endregion
        [HttpPost("create")]
        public async Task<IActionResult> Create(DepartmentCreateDTO model)
        {
            return Ok(await _departmentService.CreateAsync(model));
        }

        #region Documentation
        /// <summary>
        /// Update department
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        #endregion
        [HttpPost("update")]
        public async Task<IActionResult> Update(DepartmentUpdateDTO model)
        {
            return Ok(await _departmentService.UpdateAsync(model));
        }

        #region Documentation
        /// <summary>
        /// Delete department
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        #endregion
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _departmentService.DeleteAsync(id));
        }
    }
}
