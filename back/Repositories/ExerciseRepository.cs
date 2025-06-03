using System;
using back.Data;
using back.Entities;

namespace back.Repositories;

public class ExerciseRepository
{
    private readonly ApplicationDbContext _context;
    public ExerciseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(Exercise exercise)
    {
        await _context.AddAsync(exercise);
        await _context.SaveChangesAsync();

        return exercise.Id;
    }
}
