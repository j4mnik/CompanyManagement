using AutoMapper;
using CompanyManagement.Application.Employee;
using CompanyManagement.Domain.Interfaces;


namespace CompanyManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task Create(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CompanyManagement.Domain.Entities.Employee>(employeeDto);

            await _employeeRepository.Create(employee);
        }
    }
}

