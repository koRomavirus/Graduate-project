using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<IActionResult> GetListEmployee(string sortingOptions = "ots")
        {
            var result = await _employeeService.GetListEmployee();
            if (!string.IsNullOrWhiteSpace(sortingOptions))
            {
                
                switch (sortingOptions)
                {
                    case "По фамилии":

                        var sortByFullName = result.OrderBy(e => e.FullName).ToList();
                        result = sortByFullName;
                    break;

                    case "По должности":

                        var sortByDuty = result.OrderBy(e => e.Duty).ToList();
                        result = sortByDuty;
                    break;
                    case "По отделу":

                        var sortByDepartment = result.OrderBy(e => e.Department).ToList();
                        result = sortByDepartment;
                    break;
                }
            }
            return Ok(result);
        }
    }
}
