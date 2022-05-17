// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using System.Data;

using BTSolution.API.Data;
using BTSolution.API.Models;
using BTSolution.API.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;


namespace BTSolution.API.Repositories;

public class UserRepository : IUserRepository
{
    #region Members

    private readonly DataContext _context;

    #endregion

    #region Constructors

    public UserRepository(DbContextOptions<DataContext> dbOptions)
    {
        _context = new DataContext(dbOptions);
    }

    #endregion

    #region Interface Members

    public async Task<User> CreateUser(User user)
    {
        var addedUser = _context.Users.Add(user).Entity; 
        await _context.SaveChangesAsync();

        return addedUser;
    }

    public async void DeleteUser(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
            throw new DataException();

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetUsers()
    {
        var user = await _context.Users.ToListAsync();
        return user;
    }

    public async Task<User> GetUser(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        return user;
    }

    #endregion
}