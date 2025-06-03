using System;
using back.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back.Configurations;

public class ExerciseUserConfiguration : IEntityTypeConfiguration<ExerciseUser>
{
    public void Configure(EntityTypeBuilder<ExerciseUser> builder)
    {
        builder.HasKey(uk => new { uk.UserId, uk.ExerciseId });

        builder
            .HasOne(uk => uk.User)
            .WithMany()
            .HasForeignKey(uk => uk.UserId);

        builder
            .HasOne(uk => uk.Exercise)
            .WithMany()
            .HasForeignKey(uk => uk.ExerciseId);
    }
}
