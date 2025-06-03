using System;
using back.Data;
using back.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<ExerciseUser>> Get(int userId)
    {
        return await _context.ExerciseUsers.Where(eu => eu.UserId == userId).Include(eu => eu.Exercise).ToListAsync();
    }
}
