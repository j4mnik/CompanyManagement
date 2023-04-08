using CompanyManagement.Application.Employee;


namespace CompanyManagement.Application.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployees();
        Task Create(EmployeeDto employee);
    }
}
