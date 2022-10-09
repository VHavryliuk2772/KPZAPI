using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistance.EntityConfigurations
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.EmployeeProjectTasks)
                .WithOne(ur => ur.Project)
                .HasForeignKey(ur => ur.ProjectId);

            builder.HasOne(x => x.Customer)
                .WithMany(c => c.Projects)
                .HasForeignKey(c => c.CustomerId);
        }
    }
}