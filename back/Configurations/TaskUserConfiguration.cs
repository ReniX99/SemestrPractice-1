using System;
using back.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back.Configurations;

public class TaskUserConfiguration : IEntityTypeConfiguration<TaskUser>
{
    public void Configure(EntityTypeBuilder<TaskUser> builder)
    {
        builder.HasKey(uk => new { uk.UserId, uk.TaskId });

        builder
            .HasOne(uk => uk.User)
            .WithMany()
            .HasForeignKey(uk => uk.UserId);

        builder
            .HasOne(uk => uk.Task)
            .WithMany()
            .HasForeignKey(uk => uk.TaskId);
    }
}
