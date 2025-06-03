using System;
using back.Data;
using back.Entities;
using Microsoft.EntityFrameworkCore;

namespace back.Repositories;

public class UserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> Add(string email, string hashedPassword)
    {
        var userModel = new User
        {
            Email = email,
            PasswordHash = hashedPassword
        };

        await _context.Users.AddAsync(userModel);
        await _context.SaveChangesAsync();

        return userModel;
    }

    public async Task<User?> GetByEmail(string email)
    {
        var userModel = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (userModel == null)
        {
            return null;
        }

        return userModel;
    }

    public async Task<List<User>> GetAll(int userId)
    {
        return await _context.Users.Where(u => u.Id != userId).ToListAsync();
    }
}
