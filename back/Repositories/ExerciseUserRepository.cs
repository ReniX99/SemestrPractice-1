using System;
using back.Data;
using back.Entities;

namespace back.Repositories;

public class ExerciseUserRepository
{
    private readonly ApplicationDbContext _context;
    public ExerciseUserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Add(List<ExerciseUser> exerciseUsers)
    {
        await _context.AddRangeAsync(exerciseUsers);
        await _context.SaveChangesAsync();
    }
}
