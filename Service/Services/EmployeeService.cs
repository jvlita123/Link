using Data.Entities;
using Data.Repositories;

namespace Service.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = _employeeRepository.GetAll().ToList();

            return employees;
        }
    }
}