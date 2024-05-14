namespace EmployeesManagement.DataAccess.Entities;

public class EmployeeEntity
{
    public Guid Id { get; set;  }

    public string Name { get; set; } = string.Empty;
    
    public int Age { get; set; }

    public string Role { get; set; } = string.Empty;
}