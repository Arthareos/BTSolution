// --------------------------------------------------------------------------------------------
// <Copyright>
//     Copyright © 2022 Simone Di Fonzo. All rights reserved.
// </Copyright>
// --------------------------------------------------------------------------------------------

using BTSolution.API.Models;


namespace BTSolution.API.Interfaces;

public interface IUserService
{
    #region Methods - Public

    public Task<User> AddUser(User user);

    public Task<List<User>> GetAllUsers();

    public Task<User?> GetUser(int userId);

    public void RemoveUser(int userId);

    public void UpdateUser(User requestUser);

    #endregion
}