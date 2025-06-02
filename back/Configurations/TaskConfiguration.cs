using System;
using back.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Entities.Task>
{
    public void Configure(EntityTypeBuilder<Entities.Task> builder)
    {
        builder.HasKey(t => t.Id);
    }
}
