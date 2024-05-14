using EmployeesManagement.Core.Models;
using EmployeesManagement.DataAccess.Repositories;

namespace EmployeesManagement.Application.Services;

public class EmployeesService : IEmployeesService
{

    
    private readonly IEmployeesRepository _employeesRepository;

    public EmployeesService(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<List<Employee>> GetAllEmployees()
    {
        return await _employeesRepository.GetEmployees();
    }

    public async Task<Guid> CreateEmployee(Employee employee)
    {
        return await _employeesRepository.CreateEmployees(employee);
    }

    public async Task<Guid> UpdateEmployee(Guid id, string name, string role, int age)
    {
        return await _employeesRepository.UpdateEmployees(id, name, role, age);
    }

    public async Task<Guid> DeleteEmployee(Guid id)
    {
        return await _employeesRepository.DeleteEmployee(id);
    }
}
    
  