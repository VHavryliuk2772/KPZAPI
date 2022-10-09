using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistance.EntityConfigurations
{
    public class EmployeeProjectTaskConfiguration : IEntityTypeConfiguration<EmployeeProjectTask>
    {
        public void Configure(EntityTypeBuilder<EmployeeProjectTask> builder)
        {
            builder.ToTable("EmployeeProjectTasks");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(e => e.Employee)
                .WithMany(x => x.EmployeeProjectTasks)
                .HasForeignKey(x => x.EmployeeId);

            builder.HasOne(e => e.DesignTask)
                .WithMany(x => x.EmployeeProjectTasks)
                .HasForeignKey(x => x.DesignTaskId);

            builder.HasOne(e => e.Project)
                .WithMany(x => x.EmployeeProjectTasks)
                .HasForeignKey(x => x.ProjectId);
        }
    }
}
