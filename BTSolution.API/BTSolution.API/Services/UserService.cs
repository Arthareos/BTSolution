// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using System.Data;

using BTSolution.API.Data;
using BTSolution.API.Interfaces;
using BTSolution.API.Models;

using Microsoft.EntityFrameworkCore;


namespace BTSolution.API.Services;

public class UserService : IUserService
{
    #region Members

    private readonly DataContext _context;

    #endregion

    #region Constructors

    public UserService(DataContext context)
    {
        _context = context;
    }

    #endregion

    #region Interface Members

    /// <summary>
    ///     Adds the user to the db
    /// </summary>
    /// <param name="user">user object to be added</param>
    public async Task<User> AddUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    /// <summary>
    ///     Queries the db for all users
    /// </summary>
    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    /// <summary>
    ///     Returns only the requested user
    /// </summary>
    /// <param name="userId">id for the requested user</param>
    public async Task<User?> GetUser(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    /// <summary>
    ///     Removes the user from the db including his accessTokens
    /// </summary>
    /// <param name="userId"></param>
    public async void RemoveUser(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        _context.Users.Remove(user);
        RemoveAllUserAccessTokens(userId);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    ///     Updates the user using the data provided
    /// </summary>
    /// <param name="requestUser">new user object</param>
    public async void UpdateUser(User requestUser)
    {
        var user = await _context.Users.FindAsync(requestUser.UserId);

        if (user == null)
            throw new DataException();

        user.UserName = requestUser.UserName;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    #endregion

    #region Methods - Private

    /// <summary>
    ///     Removes all the AccessTokens assigned to a user
    /// </summary>
    /// ///
    /// <param name="userId">id for the requested user</param>
    private void RemoveAllUserAccessTokens(int userId)
    {
        var user = _context.Users.FindAsync(userId).Result;

        if (user == null)
            return;

        var userAccessTokenList = _context.AccessTokens.Where(token => token.UserId == userId).ToListAsync().Result;

        _context.AccessTokens.RemoveRange(userAccessTokenList);
        _context.SaveChanges();
    }

    #endregion
}