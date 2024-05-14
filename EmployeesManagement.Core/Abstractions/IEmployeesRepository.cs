using EmployeesManagement.Core.Models;

namespace EmployeesManagement.DataAccess.Repositories;

public interface IEmployeesRepository
{
    Task<List<Employee>> GetEmployees();
    Task<Guid> CreateEmployees(Employee employee);

    Task<Guid> UpdateEmployees(Guid id, string name, string role, int age);
    Task<Guid> DeleteEmployee(Guid id);

}