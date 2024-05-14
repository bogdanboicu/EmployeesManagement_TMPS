namespace WebApplication1.Contracts;

public record EmployeesRequest(
    Guid Id,
    string Name,
    int Age,
    string Role);