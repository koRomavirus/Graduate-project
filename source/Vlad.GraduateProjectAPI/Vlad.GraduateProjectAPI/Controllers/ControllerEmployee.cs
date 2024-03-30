using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vlad.GraduateProjectAPI.Service.Interface;

namespace Vlad.GraduateProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerEmployee : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public ControllerEmployee(IEmployeeService employees)
        {
            _employeeService = employees;
        }
        [HttpGet]
        public async Task<IActionResult> GetListEmployee()
        {
            var result = await _employeeService.GetListEmployee();
            return Ok(result);
        }
    }
}
