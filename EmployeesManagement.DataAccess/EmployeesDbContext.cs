using EmployeesManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManagement.DataAccess;

public class EmployeesDbContext : DbContext
{
    public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options)
        : base(options)
    {
    }
    public DbSet<EmployeeEntity> Employees { get; set;  }
}