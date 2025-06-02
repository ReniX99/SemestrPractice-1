using System;
using back.Configurations;
using back.Entities;
using Microsoft.EntityFrameworkCore;

namespace back.Data;

public class ApplicationDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<User> Users { get; set; }
    public DbSet<TaskUser> TaskUsers { get; set; }
    public DbSet<Entities.Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TaskConfiguration());
        modelBuilder.ApplyConfiguration(new TaskUserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
