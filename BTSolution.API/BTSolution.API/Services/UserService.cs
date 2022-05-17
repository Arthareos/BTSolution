// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using BTSolution.API.Models;
using BTSolution.API.Repositories.Interfaces;


namespace BTSolution.API.Services;

public class UserService
{
    #region Members

    private readonly IUserRepository _userRepository;

    #endregion

    #region Constructors

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    #endregion

    #region Methods - Public

    /// <summary>
    ///     Adds the user to the db
    /// </summary>
    /// <param name="userName"></param>
    public async Task<User> AddUser(string userName)
    {
        User user = new() {UserName = userName};
        return await _userRepository.CreateUser(user);
    }

    /// <summary>
    ///     Queries the db for all users
    /// </summary>
    public async Task<List<User>> GetUsers()
    {
        return await _userRepository.GetUsers();
    }
    
    /// <summary>
    ///     Queries the db for a specific user
    /// </summary>
    public async Task<User> GetUser(int userId)
    {
        return await _userRepository.GetUser(userId);
    }

    /// <summary>
    ///     Removes the user from the db including his accessTokens
    /// </summary>
    /// <param name="userId"></param>
    public void RemoveUser(int userId)
    {
        _userRepository.DeleteUser(userId);
    }

    #endregion
}