using System;
using back.Data;
using back.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Exercise?> Get(int exerciseId)
    {
        return await _context.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId);
    }

    public async Task Update()
    {
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Exercise exercise)
    {
        _context.Remove(exercise);
        await _context.SaveChangesAsync();
    }
}
