using EmployeesManagement.Core.Models;
using EmployeesManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManagement.DataAccess.Repositories;

public class EmployeesRepository: IEmployeesRepository
{
    private readonly EmployeesDbContext _context;

    public EmployeesRepository(EmployeesDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetEmployees()
    {
        var employeeEntities = await _context.Employees.AsNoTracking().ToListAsync();

        var employees = employeeEntities.Select(b => Employee.Create(b.Id, b.Name, b.Age, b.Role).Employee).ToList();

        return employees;
    }

    public async Task<Guid> CreateEmployees(Employee employee)
    {
        var employeeEntity = new EmployeeEntity
        {
            Id = employee.Id,
            Name = employee.Name,
            Age = employee.Age,
            Role = employee.Role,

        };
        await _context.Employees.AddAsync(employeeEntity);
        await _context.SaveChangesAsync();

        return employeeEntity.Id;
    }

    public async Task<Guid> UpdateEmployees(Guid id, string name, string role, int age)
    {
        _context.Employees
            .Where(b => b.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => name)
                .SetProperty(b => b.Role, b => role)
                .SetProperty(b => b.Age, b => age)
                .SetProperty(b => b.Id, b => id));


        return id;
    
}

    public async Task<Guid> DeleteEmployee(Guid id)
    {
        await _context.Employees
            .Where(b => b.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}