namespace EmployeesManagement.Core.Models
{
    public abstract class Employee
    {
        public const int MAX_NAME_LENGTH = 250;
        
        public Guid Id { get; }

        public string Name { get; }
        
        public int Age { get;}
        
        public string Role { get; }

        protected Employee(Guid id, string name, int age, string role)
        {
            Id = id;
            Name = name;
            Age = age;
            Role = role;
        }

        public static (Employee Employee, string Error) Create(Guid id, string name, int age, string role)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = "Name cannot be empty or longer than 250 characters";
            }
                
            return (null, error); // Default implementation, each specific factory will override this
        }
    }

    public class Developer : Employee
    {
        public Developer(Guid id, string name, int age, string role) : base(id, name, age, role)
        {
        }

        public static new (Developer Employee, string Error) Create(Guid id, string name, int age, string role)
        {
            return (new Developer(id, name, age, role), "");
        }
    }

    public class HR : Employee
    {
        public HR(Guid id, string name, int age, string role) : base(id, name, age, role)
        {
        }

        public static new (HR Employee, string Error) Create(Guid id, string name, int age, string role)
        {
            return (new HR(id, name, age, role), "");
        }
    }

    public class Tester : Employee
    {
        public Tester(Guid id, string name, int age, string role) : base(id, name, age, role)
        {
        }

        public static new (Tester Employee, string Error) Create(Guid id, string name, int age, string role)
        {
            return (new Tester(id, name, age, role), "");
        }
    }

    public class Manager : Employee
    {
        public Manager(Guid id, string name, int age, string role) : base(id, name, age, role)
        {
        }

        public static new (Manager Employee, string Error) Create(Guid id, string name, int age, string role)
        {
            return (new Manager(id, name, age, role), "");
        }
    }

    public static class EmployeeFactory
    {
        public static (Employee Employee, string Error) CreateEmployee(Guid id, string name, int age, string role)
        {
            switch (role.ToLower())
            {
                case "developer":
                    return Developer.Create(id, name, age, role);
                case "hr":
                    return HR.Create(id, name, age, role);
                case "tester":
                    return Tester.Create(id, name, age, role);
                case "manager":
                    return Manager.Create(id, name, age, role);
                default:
                    return (null, "Invalid role specified");
            }
        }
    }
}
