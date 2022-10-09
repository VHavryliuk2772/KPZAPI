using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistance.EntityConfigurations
{
    internal class DesignTaskConfiguration : IEntityTypeConfiguration<DesignTask>
    {
        public void Configure(EntityTypeBuilder<DesignTask> builder)
        {
            builder.ToTable("DesignTasks");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.EmployeeProjectTasks)
                .WithOne(ur => ur.DesignTask)
                .HasForeignKey(ur => ur.DesignTaskId);
        }
    }
}