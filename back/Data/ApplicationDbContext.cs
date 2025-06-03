using System;
using back.Configurations;
using back.Entities;
using Microsoft.EntityFrameworkCore;

namespace back.Data;

public class ApplicationDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<User> Users { get; set; }
    public DbSet<ExerciseUser> ExerciseUsers { get; set; }
    public DbSet<Exercise> Exercises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
        modelBuilder.ApplyConfiguration(new ExerciseUserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
