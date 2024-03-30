using Vlad.GraduateProjectAPI.DTO;

namespace Vlad.GraduateProjectAPI.Service.Interface
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDto>> GetListEmployee();
        
    }
}
