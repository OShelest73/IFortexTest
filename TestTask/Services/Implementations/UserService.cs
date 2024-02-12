using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Enums;

namespace TestTask.Services.Implementations;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {

        _dbContext = dbContext;
    }

    public async Task<User> GetUser()
    {
        var user = await _dbContext.Users
            .OrderByDescending(u => u.Orders.Count)
            .FirstOrDefaultAsync();

        return user;
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _dbContext.Users.Where(u => u.Status == UserStatus.Inactive).ToListAsync();

        return users;
    }
}