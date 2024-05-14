namespace WebApplication1.Contracts;
  public record EmployeesResponse(
        Guid Id,
        string Name,
        int Age,
        string Role);