using EmployeesManagement.Core.Models;

namespace EmployeesManagement.Application.Services;

public interface IEmployeesService
{
    Task<List<Employee>> GetAllEmployees();
    Task<Guid> CreateEmployee(Employee employee);
    Task<Guid> UpdateEmployee(Guid id, string name, string role, int age);
    Task<Guid> DeleteEmployee(Guid id);
}