using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;
using Vlad.GraduateProjectAPI.DTO;
using Vlad.GraduateProjectAPI.Persistence;
using Vlad.GraduateProjectAPI.Service.Interface;

namespace Vlad.GraduateProjectAPI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _connectionString;

        public EmployeeService(IConfiguration configuration, ApplicationDbContext context )
        {
            _connectionString = configuration.GetConnectionString("AtomexDbConnection");
            _context = context;
        }


        public async Task<List<EmployeeDto>> GetListEmployee()
        {
            var employees = new List<EmployeeDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("GetPeopleData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                   

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var employee = new EmployeeDto
                            {
                                Id = reader.GetInt32("ManKeyA"),
                                FullName = reader.GetString("ManNameA"),
                                Duty = reader.GetString("Duty"),
                                Department = reader.GetString("Dep"),
                                Phone = reader.GetString("Phone")
                                
                            };

                            employees.Add(employee);
                        }
                    }
                }
            }
            return employees;
        }
    }
}
