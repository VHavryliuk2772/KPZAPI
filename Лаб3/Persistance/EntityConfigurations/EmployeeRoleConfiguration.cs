using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistance.EntityConfigurations
{
    internal class EmployeeRoleConfiguration : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder.ToTable("EmployeeRoles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Role)
                .WithMany(p => p.EmployeeRoles)
                .HasForeignKey(x => x.RoleId);

            builder.HasOne(x => x.Employee)
                .WithMany(c => c.EmployeeRoles)
                .HasForeignKey(x => x.EmployeeId);
        }
    }
}