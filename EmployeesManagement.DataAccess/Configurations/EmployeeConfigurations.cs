using EmployeesManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeesManagement.Core;
using EmployeesManagement.Core.Models;

namespace EmployeesManagement.DataAccess.Configurations;

public class EmployeeConfigurations : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(b => b.Name)
            .HasMaxLength(Employee.MAX_NAME_LENGTH)
            .IsRequired();

        builder.Property(b => b.Age)
            .IsRequired();

        builder.Property(b => b.Role)
            .IsRequired();
    }
}